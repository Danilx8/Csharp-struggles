using System.Xml;

namespace Ninth_Laba
{
    class Model
    {
        private string mainFolderPath;
        private string secondaryFolderPath;
        private string[] MainFolderFiles;
        private string[] SecondaryFolderFiles;
        public Model(string MainFolderPath, string SecondaryFolderPath)
        {
            MainFolderFiles = Directory.GetFiles(MainFolderPath);
            SecondaryFolderFiles = Directory.GetFiles(SecondaryFolderPath);
            mainFolderPath = MainFolderPath;
            secondaryFolderPath = SecondaryFolderPath;
        }

        public bool Synchronize()
        {
            bool Success = true;
            try
            {
                foreach (string FilePath in SecondaryFolderFiles)
                {
                    File.Delete(FilePath);
                }

                foreach (string FilePath in MainFolderFiles)
                {
                    string FileName = Path.GetFileName(FilePath);
                    File.Copy(FilePath, secondaryFolderPath + @"\" + FileName);
                }
            }
            catch (Exception)
            {
                Success = false;
            }
            return Success;
        }

        public Synchronizations CheckStates()
        {
            string[] files = Directory.GetFiles(mainFolderPath);
            files.CopyTo(MainFolderFiles, 0);
            for (int FileIndex = 0; FileIndex < files.Length; ++FileIndex)
            {
                files[FileIndex] = Path.GetFileName(files[FileIndex]);
            }
            string[] updatedMainFolderFiles = files;

            files = Directory.GetFiles(secondaryFolderPath);
            for (int FileIndex = 0; FileIndex < files.Length; ++FileIndex)
            {
                files[FileIndex] = Path.GetFileName(files[FileIndex]);
            }
            string[] updatedSecondaryFolderFiles = files;

            string[] addedFiles = Array.Empty<string>();
            string[] deletedFiles = Array.Empty<string>();
            IEnumerable<string> addedFilesCollection = updatedSecondaryFolderFiles.Except(updatedMainFolderFiles);
            IEnumerable<string> deletedFilesCollection = updatedMainFolderFiles.Except(updatedSecondaryFolderFiles);
            List<string> UpdatedFiles = new();
            Synchronizations Result = new();

            if (addedFilesCollection != null)
            {
                addedFiles = (addedFilesCollection.ToArray());
            }

            if (deletedFilesCollection != null)
            {
                deletedFiles = (deletedFilesCollection.ToArray());
            }

            foreach (string FilePath in MainFolderFiles)
            {
                string MainFileName = Path.GetFileName(FilePath);
                string SecondaryPath = secondaryFolderPath + @"\" + MainFileName;
                if (File.Exists(SecondaryPath)) {
                    using StreamReader MainFile = new(FilePath);
                    using StreamReader SecondaryFile = new(SecondaryPath);
                    if (!Enumerable.SequenceEqual(File.ReadAllBytes(FilePath), File.ReadAllBytes(SecondaryPath)))
                    {
                        UpdatedFiles.Add(MainFileName);
                    }
                }
            }

            if (addedFiles.Length != 0)
            {
                Result.Add("Add", addedFiles);
            }

            if (deletedFiles.Length != 0)
            {
                Result.Add("Delete", deletedFiles);
            }

            if (UpdatedFiles.Count != 0)
            {
                Result.Add("Edit", UpdatedFiles.ToArray());
            }

            //if (Result.Count == 0)
            //{
            //    string[] AllGood = { "Все файлы синхронизированы!" };
            //    Result.Add("Nothing", AllGood);
            //}

            using (XmlWriter Writer = XmlWriter.Create("Sessions.xml"))
            {
                Result.WriteXml(Writer);
            }

            Result.WriteJson();
            //Writer.WriteEndElement();
            return Result;
        }
    }
}
