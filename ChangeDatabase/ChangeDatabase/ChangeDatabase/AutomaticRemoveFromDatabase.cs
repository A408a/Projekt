﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChangeDatabase
{
    public class AutomaticRemoveFromDatabase
    {
        public List<FileInfo> FileNameError { get; private set; } = new List<FileInfo>();
        public string Dir()
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\"));
            return path;
        }

        public void FindOutdatedFolder()
        {
            string DirectoryName = "TestFolder"; //Nyheder_Database
            string path = Directory.GetCurrentDirectory();
            
            //Path goes 3 folders up.
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\"));

            path = Path.Combine(path, DirectoryName);
            DirectoryInfo Dir = new DirectoryInfo(path);

            foreach (DirectoryInfo Tag in Dir.GetDirectories())
            {
                BrowseTags(Tag);
            }
        }

        private void BrowseTags(DirectoryInfo Dir)
        {
            DirectoryInfo DirTrue = new DirectoryInfo(Path.Combine(Dir.FullName, "True"));
            DirectoryInfo DirFalse = new DirectoryInfo(Path.Combine(Dir.FullName, "False"));

            // Goes through all true articles
            foreach (FileInfo file in DirTrue.GetFiles())
                FindOutdatedFile(file.ToString(), file);

            // Goes through all false articles
            foreach (FileInfo file in DirFalse.GetFiles())
                FindOutdatedFile(file.ToString(), file);
        }

        private void FindOutdatedFile(string File, FileInfo FileInformation)
        {
            try
            {
                int month = Int32.Parse(File.Substring(3, 2));
                int year = Int32.Parse(File.Substring(6, 4));

                // If an article has an invalid Date.
                if (year > DateTime.Now.Year || year < 0 || month > 12 || month < 0)
                    throw new InvalidDateException();

                // If current year is equal to article year
                if (year == DateTime.Now.Year)
                {
                    // If article is less than 3 months old
                    if (month < DateTime.Now.Month - 3)
                        RemoveFile(FileInformation);
                }
                else
                {
                    RemoveFile(FileInformation);
                }
            }
            // If the file name has an error, like an invalid date: 39_14_2090, or does not meet the requirements: Name_01_01_2010.
            // Catched exceptions is sent to a list of failed files, which is then later handled.
            catch (FormatException)
            {
                FileNameError.Add(FileInformation);
            }
            catch (InvalidDateException)
            {
                FileNameError.Add(FileInformation);
            }
        }

        private void RemoveFile(FileInfo FileInformation)
        {
            FileInformation.Delete();
        }


        // Handles exceptions. Is called from GUI
        public void HandleException(FileInfo FileInformation, string UserChoice)
        {
            if (UserChoice == "Delete")
                FileInformation.Delete();
            else
            {
                // Sets title as the input, with date as current day.
                string Title = "_" + UserChoice + ".txt";
                string CurrentDate = DateTime.Now.ToString("dd_MM_yyyy_");
                string TargetPath = FileInformation.DirectoryName;

                Title = "\\" + CurrentDate + Title;
                TargetPath = Path.Combine(TargetPath + Title);
                File.Move(FileInformation.FullName, TargetPath);
            }
        }
    }
}
