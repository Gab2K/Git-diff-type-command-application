using System.Collections.Generic;
using System.IO;

namespace Git_diff
{
	public class differenceCheck
	{

		//Arguments: Name of a file, list where text from file is going to be added
		public static void loadFiles(string fileName, List<string> fileInList)
		
		{
			int lineNumber = 1;
			// Read the file line by line and append to a list
			using StreamReader reader = new StreamReader(fileName);
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				fileInList.Add($"[Line: {lineNumber}]");
				fileInList.Add(line); //Adds to a list
				lineNumber++;
			}


		}


		//Arguments: First split list, Second split list, List where everything is going to be added
		public static void compareFiles(List<string> file1, List<string> file2, List<string> taken, List<string> added)
		
		{
			//Gets the shorter list for the loop
			int shorter;
			if (file1.Count < file2.Count)
			{
				shorter = file1.Count;
			}
			else
			{
				shorter = file2.Count;
			}


			for (int i = 0; i < shorter; i++)
			{
				//Spliting each line into words

				char[] splitCharacters = {(char)32, (char)39}; //space and apostrophe
				string[] file1Split = file1[i].Split(splitCharacters);
				string[] file2Split = file2[i].Split(splitCharacters);

				
				if (file1Split.Length > file2Split.Length) //If file 1 is longer then words have been removed
				{
					for (int j = 0; j < file2Split.Length; j++)
					{
						if (file1Split[j] != file2Split[j])
						{
							taken.Add($"'{file1Split[j]}' removed at line {(i+1)/2} index {j+1} " +
								$"and replaced with '{file2Split[j]}'");
						}
					}

				}
				else //Otherwise it is bigger or the same, so words have been added
				{
					for (int k = 0; k < file1Split.Length; k++)
					{
						if (file1Split[k] != file2Split[k])
						{
							added.Add($"'{file2Split[k]}' added at line {(i+1)/2} index {k + 1}, " +
								$"replacing '{file1Split[k]}'");
						}
					}

				}
			}



		}
	}
	}




	



