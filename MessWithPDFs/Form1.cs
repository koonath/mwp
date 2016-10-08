using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using pdfforge;
using iTextSharp;

namespace MessWithPDFs
{
    public partial class Form1 : Form
    {        
        private List<string> filePathsList;
        private string[] files;
        private string destinationFilePath;
        private string currentUser;
        private string now;
        private enum features {None, Merge, Explode, StampImage, ExtractPages, threeDPDF};
        private int actionSelected;        

        public Form1()
        {
            InitializeComponent();

            filePathsList = new List<string>();
            files = null;
            actionSelected = (int)features.None;

            currentUser = System.Environment.UserName;
            now = ProvideDateTimeNow();
            destinationFilePath = @"C:\Users\" + currentUser + @"\Desktop\" + now + ".pdf";

            HideAll();

            ActionBox.Show();            
        }

        private void ActionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox temp = (ComboBox)sender;
            actionSelected = temp.SelectedIndex;
            if (actionSelected == 0)
            {
                HideAll();
                Forget(true);                
            }
            else if (actionSelected == (int)features.Merge)
            {
                HideAll();
                Forget(true);
                ShowMergeItems();
            }
            else if (actionSelected == (int)features.Explode)
            {
                HideAll();
                Forget(true);
                ShowExplodeItems();
            }
            else if (actionSelected == (int)features.StampImage)
            {
                HideAll();
                Forget(true);
                ShowStampItems();
            }
            else if (actionSelected == (int)features.ExtractPages)
            {
                HideAll();
                Forget(true);
                ShowExtractPagesItem();
            }
            else if (actionSelected == (int)features.threeDPDF)
            {
                HideAll();
                Forget(true);
                Show3DpdfItems();
                #region Commented out
                //string pdfpath = @"C:\Users\s.surendran\Desktop\";
                //string imagepath = @"C:\Users\s.surendran\Pictures\Screenshots";
                //iTextSharp.text.Document doc = new iTextSharp.text.Document();
                //try
                //{
                //    iTextSharp.text.PdfWriter.GetInstance(doc, new FileStream(pdfpath + "/Images.pdf", FileMode.Create));
                //    doc.Open();

                //    doc.Add(new iTextSharp.text.Paragraph("GIF"));
                //    Image png = Image.FromFile(imagepath + "/ifcplate.PNG");

                //    doc. .Add(png);
                //}
                //catch (Exception ex)
                //{
                //    //Log error;
                //}
                //finally
                //{
                //    doc.Close();
                //}
                #endregion
            }
        }

        private void FileNameBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }            
        }

        private void FileNameBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (FileNameBox.SelectedItem == null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] fileNames;
                    fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                    //if (actionSelected == (int)features.Merge)
                    {
                        foreach (string name in fileNames)
                        {
                            int length = name.Length - 1;
                            string temp = System.IO.Path.GetExtension(name).ToLower();
                            string[] split = name.Split('\\');
                            if (temp == ".pdf")
                            {
                                FileNameBox.Items.Add(split[split.Length - 1]);
                                PathsListBox.Items.Add(name);
                            }
                        }
                    }
                    //else if (actionSelected == (int)features.Explode)
                    //{
                    //    int length = fileNames[0].Length - 1;
                    //    string temp = fileNames[0].Substring(length - 2);
                    //    string[] split = fileNames[0].Split('\\');
                    //    if (temp == "pdf")
                    //    {
                    //        FileNameBox.Items.Clear();
                    //        PathsListBox.Items.Clear();
                    //        FileNameBox.Items.Add(split[split.Length - 1]);
                    //        PathsListBox.Items.Add(fileNames[0]);
                    //    }
                    //}                   
                }
            }
            else
            {
                if (PathsListBox.SelectedItem == null)
                {
                    Point point = FileNameBox.PointToClient(new Point(e.X, e.Y));
                    int index = FileNameBox.IndexFromPoint(point);
                    if (index < 0)
                        index = FileNameBox.Items.Count - 1;
                    object dataFileNameBox = e.Data.GetData(DataFormats.Text);
                    object dataPathsListBox = PathsListBox.Items[FileNameBox.SelectedIndex];
                    PathsListBox.Items.Remove(dataPathsListBox);
                    PathsListBox.Items.Insert(index, dataPathsListBox);
                    FileNameBox.Items.Remove(dataFileNameBox);
                    FileNameBox.Items.Insert(index, dataFileNameBox);
                }
            }
        }

        private void FileNameBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void FileNameBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (FileNameBox.SelectedItem == null)
                return;
            FileNameBox.DoDragDrop(FileNameBox.SelectedItem, DragDropEffects.Move);
        }

        private void PathsListBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PathsListBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (PathsListBox.SelectedItem == null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] fileNames;
                    fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                    //if (actionSelected == (int)features.Merge)
                    {
                        foreach (string name in fileNames)
                        {
                            int length = name.Length - 1;
                            string temp = System.IO.Path.GetExtension(name).ToLower();
                            string[] split = name.Split('\\');
                            if (temp == ".pdf")
                            {
                                FileNameBox.Items.Add(split[split.Length - 1]);
                                PathsListBox.Items.Add(name);
                            }
                        }
                    }
                    //else if (actionSelected == (int)features.Explode)
                    //{
                    //    int length = fileNames[0].Length - 1;
                    //    string temp = fileNames[0].Substring(length - 2);
                    //    string[] split = fileNames[0].Split('\\');
                    //    if (temp == "pdf")
                    //    {
                    //        FileNameBox.Items.Clear();
                    //        PathsListBox.Items.Clear();
                    //        FileNameBox.Items.Add(split[split.Length - 1]);
                    //        PathsListBox.Items.Add(fileNames[0]);
                    //    }
                    //} 
                }
            }
            else 
            {
                if (FileNameBox.SelectedItem == null)
                {
                    Point point = PathsListBox.PointToClient(new Point(e.X, e.Y));
                    int index = PathsListBox.IndexFromPoint(point);
                    if (index < 0)
                        index = PathsListBox.Items.Count - 1;
                    object dataPathsListBox = e.Data.GetData(DataFormats.Text);
                    object dataFileNameBox = FileNameBox.Items[PathsListBox.SelectedIndex];
                    FileNameBox.Items.Remove(dataFileNameBox);
                    FileNameBox.Items.Insert(index, dataFileNameBox);
                    PathsListBox.Items.Remove(dataPathsListBox);
                    PathsListBox.Items.Insert(index, dataPathsListBox);
                }
            }
        }

        private void PathsListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void PathsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (PathsListBox.SelectedItem == null)
                return;
            PathsListBox.DoDragDrop(PathsListBox.SelectedItem, DragDropEffects.Move);
        }

        private void DestinationFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            destinationFilePath = temp.Text;
        }

        private void StampFileBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void StampFileBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (StampFileBox.SelectedItem == null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] fileNames;
                    fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                    {
                        int length = fileNames[0].Length - 1;
                        string temp = System.IO.Path.GetExtension(fileNames[0]).ToLower();
                        string[] split = fileNames[0].Split('\\');
                        if ((temp == ".pdf") || (temp == ".png") || (temp == ".jpg") || (temp == ".jpeg") || (temp == ".bmp") || (temp == ".gif") || (temp == ".tif") || (temp == ".tiff") || (temp == ".dib") || (temp == ".jpe") || (temp == ".jiff"))
                        {
                            StampFileBox.Items.Clear();
                            //StampFileBox.Items.Add(split[split.Length - 1]);
                            StampFileBox.Items.Add(fileNames[0]);
                        }
                    }                   
                }
            }
            else
            {
                //if (PathsListBox.SelectedItem == null)
                {
                    Point point = StampFileBox.PointToClient(new Point(e.X, e.Y));
                    int index = StampFileBox.IndexFromPoint(point);
                    if (index < 0)
                        index = StampFileBox.Items.Count - 1;
                    object dataStampFileBox = e.Data.GetData(DataFormats.Text);
                    StampFileBox.Items.Remove(dataStampFileBox);
                    StampFileBox.Items.Insert(index, dataStampFileBox);
                }
            }
        }

        private void StampFileBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void StampFileBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (StampFileBox.SelectedItem == null)
                return;
            StampFileBox.DoDragDrop(StampFileBox.SelectedItem, DragDropEffects.Move);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            //if (actionSelected == (int)features.Merge || actionSelected == (int)features.Explode || actionSelected == (int)features.StampImage)
            {
                if (PathsListBox.SelectedItem != null)
                {
                    FileNameBox.Items.RemoveAt(PathsListBox.SelectedIndex);
                    PathsListBox.Items.Remove(PathsListBox.SelectedItem);
                }
                else if (FileNameBox.SelectedItem != null)
                {
                    PathsListBox.Items.RemoveAt(FileNameBox.SelectedIndex);
                    FileNameBox.Items.Remove(FileNameBox.SelectedItem);
                }
            }            
        }

        private void RemoveAllButton_Click(object sender, EventArgs e)
        {
            Forget(true);
        }

        private void RemoveImageButton_Click(object sender, EventArgs e)
        {
            StampFileBox.Items.Clear();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            pdfforge.PDF.PDF pdf = new pdfforge.PDF.PDF();

            if (actionSelected == (int)features.Merge)
                Merge(pdf);
            else if (actionSelected == (int)features.Explode)
                Explode(pdf);
            else if (actionSelected == (int)features.StampImage)
                Stamp(pdf);                
            pdf = null;            
        }        

        private void Merge(pdfforge.PDF.PDF pdf)
        {
            foreach (object item in PathsListBox.Items)
                filePathsList.Add(PathsListBox.GetItemText(item));

            if (filePathsList.Count == 0)
                MessageBox.Show("No files added for merging!");
            else
            {
                bool exist = System.IO.File.Exists(destinationFilePath);
                if ((exist == true) /*&& (overwriteSwitch == false)*/)
                    MessageBox.Show("File already exists, please enter new file name");
                else
                {
                    files = filePathsList.ToArray();
                    pdf.MergePDFFiles(ref files, destinationFilePath, false);
                    System.Diagnostics.Process.Start(destinationFilePath);
                    Forget(false);
                }
            }
        }

        private void Explode(pdfforge.PDF.PDF pdf)
        {
            foreach (object item in PathsListBox.Items)
                filePathsList.Add(PathsListBox.GetItemText(item));

            if (filePathsList.Count == 0)
                MessageBox.Show("No files added for exploding!");
            else
            {
                foreach (string sourcePath in filePathsList)
                    pdf.SplitPDFFile(sourcePath, sourcePath);
                Forget(true);
            }
        }

        private void Stamp(pdfforge.PDF.PDF pdf)
        {
            foreach (object item in PathsListBox.Items)
                filePathsList.Add(PathsListBox.GetItemText(item));

            if (filePathsList.Count == 0)
                MessageBox.Show("No PDFs added for stamping!");
            else if (StampFileBox.Items.Count == 0)
                MessageBox.Show("No image added for stamping!");
            else
            {
                foreach (string sourceFile in filePathsList)
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(sourceFile);
                    string filePath = System.IO.Path.GetDirectoryName(sourceFile);

                    string destinationFile = filePath + @"\" + fileName + "_1.pdf";
                    bool exist = System.IO.File.Exists(destinationFile);
                    while (exist == true)
                    {
                        fileName = System.IO.Path.GetFileNameWithoutExtension(destinationFile);
                        destinationFile = filePath + @"\" + fileName + "_1.pdf";
                        exist = System.IO.File.Exists(destinationFile);
                    }

                    int numberOfPages = pdf.NumberOfPages(sourceFile);
                    
                    string stamp = StampFileBox.GetItemText(StampFileBox.Items[0]);

                    string extension = System.IO.Path.GetExtension(stamp).ToLower();
                    
                    if (extension == ".pdf")
                    {
                        if (StampAllButton.Checked == true)
                            pdf.StampPDFFileWithPDFFile(sourceFile, destinationFile, stamp, 1, numberOfPages, true, 0.8f, 9);
                        else if (StampLastPageButton.Checked == true)
                            pdf.StampPDFFileWithPDFFile(sourceFile, destinationFile, stamp, numberOfPages, numberOfPages, true, 0.9f, 9);
                    }
                    else
                    {
                        if (StampAllButton.Checked == true)
                            pdf.StampPDFFileWithImage(sourceFile, destinationFile, stamp, 1, numberOfPages, true, 0.8f, 9);
                        else if (StampLastPageButton.Checked == true)
                            pdf.StampPDFFileWithImage(sourceFile, destinationFile, stamp, numberOfPages, numberOfPages, true, 0.8f, 9);
                    }
                }
                Forget(true);
            }
        }

        private void HideAll()
        {
            HideMergeItems();
            HideStampItems();
        }

        private void HideMergeItems()
        {            
            InstructionsLabel1.Hide();
            InstructionsLabel2.Hide();
            FileNameBox.Hide();
            PathsListBox.Hide();
            DestinationFilePathTextBox.Hide();
            RemoveButton.Hide();
            RemoveAllButton.Hide();
            GoButton.Hide();
            HidePathsButton.Hide();
        }

        private void HideStampItems()
        {
            StampFileBox.Hide();
            RemoveImageButton.Hide();
            StampAllButton.Hide();
            StampLastPageButton.Hide();            
        }

        private void ShowMergeItems()
        {
            InstructionsLabel1.Show();
            InstructionsLabel1.Text = "Drag and drop PDF files to merge, into the box below:";
            InstructionsLabel2.Show();
            InstructionsLabel2.Text = "Full file path for merged file:";
            FileNameBox.Show();
            PathsListBox.Show();
            DestinationFilePathTextBox.Show();
            DestinationFilePathTextBox.Text = destinationFilePath;
            RemoveButton.Show();
            RemoveAllButton.Show();
            GoButton.Show();
            GoButton.Text = "Merge";
            HidePathsButton.Show();
            HidePathsButton.Text = "Hide Paths";
        }

        private void ShowExplodeItems()
        {            
            InstructionsLabel1.Show();
            InstructionsLabel1.Text = "Drag and drop PDF files to explode, into the box below:";
            //InstructionsLabel2.Show();
            //InstructionsLabel2.Text = "Full file path for exploded pages";
            FileNameBox.Show();
            PathsListBox.Show();
            //DestinationFilePathTextBox.Show();
            //DestinationFilePathTextBox.Text = destinationFilePath;
            RemoveButton.Show();
            RemoveAllButton.Show();
            GoButton.Show();
            GoButton.Text = "Kaboom!";
            HidePathsButton.Show();
            HidePathsButton.Text = "Hide Paths";
        }

        private void ShowStampItems()
        {
            InstructionsLabel1.Show();
            InstructionsLabel1.Text = "Drag and drop PDF files that need stamping, into the box below:";
            InstructionsLabel2.Show();
            InstructionsLabel2.Text = "Drag and drop image/PDF into the box:";
            FileNameBox.Show();
            PathsListBox.Show();
            StampFileBox.Show();
            RemoveButton.Show();
            RemoveAllButton.Show();
            RemoveImageButton.Show();
            GoButton.Show();
            GoButton.Text = "Stamp";
            HidePathsButton.Show();
            HidePathsButton.Text = "Hide Paths";
            StampAllButton.Show();
            StampAllButton.Checked = true;
            StampLastPageButton.Show();
        }

        private void ShowExtractPagesItem()
        {
            InstructionsLabel1.Show();
            InstructionsLabel1.Text = "Oops! Feature is still under construction.";
        }

        private void Show3DpdfItems()
        {
            InstructionsLabel1.Show();
            InstructionsLabel1.Text = "Oops! Feature is still under construction.";
        }

        private string ProvideDateTimeNow()
        {
            string year = System.DateTime.Now.Year.ToString();
            string month = System.DateTime.Now.Month.ToString();
            string day = System.DateTime.Now.Day.ToString();
            string hour = System.DateTime.Now.Hour.ToString();
            string minute = System.DateTime.Now.Minute.ToString();
            string second = System.DateTime.Now.Second.ToString();

            month = AddZero(month);
            day = AddZero(day);
            hour = AddZero(hour);
            minute = AddZero(minute);
            second = AddZero(second);

            string temp = year + month + day + "_" + hour + minute + second;
            return temp;
        }

        public string AddZero(string number)
        {
            if (number.Length == 1)
                return "0" + number;
            else
                return number;
        }

        private void Forget(bool all)
        {
            if (all == true)
            {                
                FileNameBox.Items.Clear();
                PathsListBox.Items.Clear();
                filePathsList.Clear();
                files = null;
            }
            //else
            //{
            //    filePathsList.Clear();
            //    files = null;
            //}
        }

        private void HidePathsButton_Click(object sender, EventArgs e)
        {
            if (PathsListBox.Visible == true)
            {
                PathsListBox.Hide();
                HidePathsButton.Text = "Show Paths";
            }
            else
            {
                PathsListBox.Show();
                HidePathsButton.Text = "Hide Paths";
            }
        }                                      
    }
}
