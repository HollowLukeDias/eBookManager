using eBookManager.Engine;
using eBookManager.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using System.Drawing;

namespace Testing
{
    public partial class eBookManager : Form
    {
        private string _jsonPath;
        private List<StorageSpace> _spaces; 
        public eBookManager() 
        { 
            InitializeComponent(); _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt"); 
        }

        private async void eBookManager_Load(object sender, EventArgs e)
        {
            _spaces = await _spaces.ReadFromDataStore(_jsonPath); 
            
            //These are used because .Net Core 3 does not support binary serialization

            // imageList1 
            imageList1.Images.Add("storage_space_cloud.png", Image.FromFile("img/storage_space_cloud.png")); 
            imageList1.Images.Add("eBook.png", Image.FromFile("img/eBook.png")); 
            imageList1.Images.Add("no_eBook.png", Image.FromFile("img/no_eBook.png"));
            imageList1.TransparentColor = System.Drawing.Color.Transparent; 
            
            // btnReadEbook 
            btnReadEbook.Image = Image.FromFile("img/ReadEbook.png");
            btnReadEbook.Location = new System.Drawing.Point( 103, 227);
            btnReadEbook.Name = "btnReadEbook";
            btnReadEbook.Size = new System.Drawing.Size(36, 40);
            btnReadEbook.TabIndex = 32; 
            toolTip1.SetToolTip(btnReadEbook, "Click here to open the eBook file location"); 
            btnReadEbook.UseVisualStyleBackColor = true; 
            btnReadEbook.Click += new System.EventHandler(btnReadEbook_Click); 

            // eBookManager 
            Icon = new System.Drawing.Icon("ico/mainForm.ico");
            PopulateStorageSpaceList();
        } 

        /// <summary>
        /// Just populates the list with all the storage spaces previously created
        /// </summary>
        private void PopulateStorageSpaceList() 
        { 
            lstStorageSpaces.Clear();
            if (!(_spaces == null)) 
            {
                foreach (StorageSpace space in _spaces) 
                { 
                    ListViewItem lvItem = new ListViewItem( space.Name, 0); 
                    lvItem.Tag = space.BookList; 
                    lvItem.Name = space.ID.ToString(); 
                    lstStorageSpaces.Items.Add( lvItem); 
                }
            }
        }

        /// <summary>
        /// Open the directory in which the file you clicked to read is located
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadEbook_Click(object sender, EventArgs e)
        {
            try
            {
                //If there are no books selected, the string will be empty
                string filePath = txtFilePath.Text;
                if (filePath == "") throw new Exception("There are no books selected!");

                //It will only open the directory when the selected book is stil there
                FileInfo fileInfo = new FileInfo(filePath);
                if (!fileInfo.Exists) throw new Exception("The selected book has been deleted or moved!");
                // TODO: Delete the book if it is no longer inside a virtual storage
                Process.Start("explorer.exe", Path.GetDirectoryName(filePath));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Happens when you click in a book in the list of books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBooks_MouseClick(object sender, EventArgs e)
        {
            ListViewItem selectedBook = lstBooks.SelectedItems[0];

            if (!String.IsNullOrEmpty(selectedBook.Tag.ToString()))
            {
                //Sets the information of the selected book on the texts
                Document ebook        = (Document)selectedBook.Tag;

                txtFileName.Text      = ebook.FileName; 
                txtExtension.Text     = ebook.Extension; 
                dtLastAccessed.Value  = ebook.LastAccessed;
                dtCreated.Value       = ebook.Created;
                txtFilePath.Text      = ebook.FilePath;
                txtFileSize.Text      = ebook.FileSize;
                txtTitle.Text         = ebook.Title; 
                txtAuthor.Text        = ebook.Author; 
                txtPublisher.Text     = ebook.Publisher; 
                txtPrice.Text         = ebook.Price;
                txtISBN.Text          = ebook.ISBN; 
                dtDatePublished.Value = ebook.PublishDate; 
                txtCategory.Text      = ebook.Category;
            }
        }

        /// <summary>
        /// Opens the ImportBooks form, allowing the user to create virtual spaces and import the books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void mnuImportEbooks_Click(object sender, EventArgs e)
        {
            ImportBooks import = new ImportBooks();
            import.ShowDialog();
            _spaces = await _spaces.ReadFromDataStore(_jsonPath);
            PopulateStorageSpaceList();
        }

        private void lstStorageSpaces_MouseClick(object sender, EventArgs e)
        {

            ListViewItem selectedStorageSpace = lstStorageSpaces.SelectedItems[0]; 
            int spaceID = selectedStorageSpace.Name.ToInt();

            //First() is used only so we can be sure it will return only one text
            txtStorageSpaceDescription.Text = (from space in _spaces
                                               where space.ID == spaceID
                                               select space.Description).First();
            List<Document> ebookList = (List<Document>)selectedStorageSpace.Tag;
            PopulateContainedBooks(ebookList);
        }

        private void PopulateContainedBooks(List<Document> ebookList)
        {
            //Clear the selections
            lstBooks.Clear();
            ClearSelectedBook();

            if(ebookList != null)
            {
                foreach(Document eBook in ebookList)
                {
                    ListViewItem book = new ListViewItem(eBook.Title, 1);
                    book.Tag = eBook;
                    lstBooks.Items.Add(book);
                }
            }
            else
            {
                ListViewItem book = new ListViewItem("This storage space contains no eBooks", 2);
                book.Tag = "";
                lstBooks.Items.Add(book);
            }
        }

        private void ClearSelectedBook()
        {
            //Changes the text of all the TextBox in the group box Book Details into "" (nothing)
            foreach (Control ctrl in gbBookDetails.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = "";  
            }
            
            //Changes the text of all the TextBox in the group box File Details into "" (nothing)
            foreach (Control ctrl in gbFileDetails.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = "";
            }
            dtLastAccessed.Value  = DateTime.Now;
            dtCreated.Value       = DateTime.Now;
            dtDatePublished.Value = DateTime.Now;
        }
    }
}
