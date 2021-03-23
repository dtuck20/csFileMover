using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConsolePhotoMover
{
    class Program
    {   
        [STAThread]
        static void Main(string[] args)
        {
            
            var folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "Select the location of the photos";
            folderDialog.ShowNewFolderButton = false;
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var saveFolderDialog = new FolderBrowserDialog();
                saveFolderDialog.Description = "Select the location to move the photos to";
                saveFolderDialog.ShowNewFolderButton = true;
                string sourcefolderpath = folderDialog.SelectedPath;
                DialogResult saveResult = saveFolderDialog.ShowDialog();

                if (saveResult == DialogResult.OK)
                {
                    string destfolderpath = saveFolderDialog.SelectedPath;

                    foreach (var folder in new DirectoryInfo(sourcefolderpath).GetDirectories())


                        foreach (var file in new DirectoryInfo(folder.FullName).GetFiles("*.*"))
                        {
                            var targetfoldername = file.CreationTime.ToString("MM-dd-yyy");
                            var dir = Directory.CreateDirectory(Path.Combine(destfolderpath, targetfoldername));
                            file.CopyTo(Path.Combine(dir.FullName, file.Name), true);
                        }

                    MessageBox.Show("Copy Completed ! :)", "Complete", MessageBoxButtons.OK);

                }
            }
            else
            {
                MessageBox.Show("Cancelled", "Copy Cancelled", MessageBoxButtons.OK);
            }
        }
    }
}
