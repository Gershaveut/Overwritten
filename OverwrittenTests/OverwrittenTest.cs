using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.SafeHandles;
using Overwritten;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OverwrittenTests
{
    [TestClass]
    public class OverwrittenTest
    {
        const string search = ".txt";
        readonly string replacement = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "OverwrittenTest.txt");
        readonly string searchDirectory = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "OverwrittenTest");
        const bool fullName = false;
        const bool nameChange = false;
        const bool undo = true;
        const bool searchSubdirectories = true;

        [TestMethod]
        public async Task ReplaceAndCancelAsync()
        {
            Overwritten.Overwritten overwritten = new Overwritten.Overwritten();

            await Task.Run(async () =>
            {
                overwritten.Replace(search, replacement, searchDirectory, fullName, nameChange, undo, searchSubdirectories);
            });

            while (overwritten.replaceWorker.IsBusy)
            {
                await Task.Delay(100);
            }

            await Task.Run(async () =>
            {
                overwritten.Cancel();
            });

            while (overwritten.cancelWorker.IsBusy)
            {
                await Task.Delay(100);
            }
        }

        [TestMethod]
        public void Arguments()
        {
            Program.args = new string[] { $"--search={search}", $"--replacement={replacement}", $"--searchDirectory={searchDirectory}", $"--fullName={fullName}", $"--nameChange={nameChange}", $"--undo={undo}", $"--searchSubdirectories={searchSubdirectories}" };

            Overwritten.Overwritten overwritten = new Overwritten.Overwritten();

            Assert.AreEqual(search, overwritten.searchCombo.Text);
            Assert.AreEqual(replacement, overwritten.replacementCombo.Text);
            Assert.AreEqual(searchDirectory, overwritten.searchDirectoryCombo.Text);
            Assert.AreEqual(fullName, overwritten.fullNameCheck.Checked);
            Assert.AreEqual(nameChange, overwritten.nameChangeCheck.Checked);
            Assert.AreEqual(undo, overwritten.undoCheck.Checked);
            Assert.AreEqual(searchSubdirectories, overwritten.searchSubdirectoriesCheck.Checked);
        }
    }
}
