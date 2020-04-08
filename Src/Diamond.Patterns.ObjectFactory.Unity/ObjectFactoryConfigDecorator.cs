﻿// ***
// *** Copyright(C) 2019-2020, Daniel M. Porrey. All rights reserved.
// *** 
// *** This program is free software: you can redistribute it and/or modify
// *** it under the terms of the GNU Lesser General Public License as published
// *** by the Free Software Foundation, either version 3 of the License, or
// *** (at your option) any later version.
// *** 
// *** This program is distributed in the hope that it will be useful,
// *** but WITHOUT ANY WARRANTY; without even the implied warranty of
// *** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// *** GNU Lesser General Public License for more details.
// *** 
// *** You should have received a copy of the GNU Lesser General Public License
// *** along with this program. If not, see http://www.gnu.org/licenses/.
// *** 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Diamond.Patterns.Abstractions;
using Microsoft.Practices.Unity.Configuration;

namespace Diamond.Patterns.ObjectFactory.Unity
{
	public static class ObjectFactoryConfigDecorator
	{
		/// <summary>
		/// Loads the Unity configuration file specified in the path.
		/// </summary>
		/// <param name="objectFactory">The Unity container instance to load the configuration into.</param>
		/// <param name="filePath">The full path to the Unity configuration file.</param>
		/// <param name="containerName">The optional Container name to load. The default loads the unnamed Container.</param>
		/// <returns></returns>
		public static Task LoadUnityConfigFromFileAsync(this IObjectFactory objectFactory, string filePath, string containerName = "")
		{
			ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
			Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
			UnityConfigurationSection unitySection = (UnityConfigurationSection)configuration.GetSection("unity");

			if (unitySection != null)
			{
				if (String.IsNullOrWhiteSpace(containerName))
				{
					_ = ((ObjectFactory)objectFactory).Unity.LoadConfiguration(unitySection);
				}
				else
				{
					_ = ((ObjectFactory)objectFactory).Unity.LoadConfiguration(unitySection, containerName);
				}
			}
			else
			{
				throw new InvalidOperationException($"The file {filePath} does not contain a valid Unity configuration section.");
			}

			return Task.FromResult(0);
		}

		/// <summary>
		/// Loads the Unity configuration files found in the specified list.
		/// </summary>
		/// <param name="objectFactory">The Unity container instance to load the configuration into.</param>
		/// <param name="files">A list of file paths where the files to be loaded are located.</param>
		public static async Task LoadUnityConfigFromFilesAsync(this IObjectFactory objectFactory, IEnumerable<string> files)
		{
			foreach (string file in files)
			{
				// ***
				// *** Load the default unity container.
				// ***
				await objectFactory.LoadUnityConfigFromFileAsync(file, null);
			}
		}

		/// <summary>
		/// Loads the Unity configuration files found in the path specified.
		/// </summary>
		/// <param name="objectFactory">The Unity container instance to load the configuration into.</param>
		/// <param name="path">The folder path where the Unity configuration files are located.</param>
		/// <param name="searchPattern">Specifies a pattern to use to match file names. The default is *.config.</param>
		/// <param name="searchOption">Specifies the search option to use. the default is SearchOption.TopDirectoryOnly.</param>
		public static async Task<IEnumerable<string>> LoadUnityConfigFromFolderAsync(this IObjectFactory objectFactory, string path, string searchPattern = "*.config", SearchOption searchOption = SearchOption.TopDirectoryOnly)
		{
			string[] files = Directory.GetFiles(path, searchPattern, searchOption);

			foreach (string file in files)
			{
				// ***
				// *** Load the default unity container.
				// ***
				await objectFactory.LoadUnityConfigFromFileAsync(file, null);
			}

			return files;
		}
	}
}
