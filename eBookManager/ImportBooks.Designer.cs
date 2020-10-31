namespace Testing
{
    partial class ImportBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectSourceFolder = new System.Windows.Forms.Button();
            this.tvFoundBooks = new System.Windows.Forms.TreeView();
            this.gpFileDetails = new System.Windows.Forms.GroupBox();
            this.dtLastAccessed = new System.Windows.Forms.DateTimePicker();
            this.dtCreated = new System.Windows.Forms.DateTimePicker();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gpBoolDetails = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtDatePublished = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassification = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnAddBookToStorageSpace = new System.Windows.Forms.Button();
            this.dbVirtalStorageSpace = new System.Windows.Forms.GroupBox();
            this.lblEbookCount = new System.Windows.Forms.Label();
            this.lblStorageSpaceDescription = new System.Windows.Forms.Label();
            this.txtStorageSpaceDescription = new System.Windows.Forms.TextBox();
            this.btnCancelNewStorageSpaceSave = new System.Windows.Forms.Button();
            this.btnSaveNewStorageSpace = new System.Windows.Forms.Button();
            this.txtNewStorageSpaceName = new System.Windows.Forms.TextBox();
            this.btnAddNewStorageSpace = new System.Windows.Forms.Button();
            this.dlVirtualStorageSpaces = new System.Windows.Forms.ComboBox();
            this.gpFileDetails.SuspendLayout();
            this.gpBoolDetails.SuspendLayout();
            this.dbVirtalStorageSpace.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectSourceFolder
            // 
            this.btnSelectSourceFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelectSourceFolder.Name = "btnSelectSourceFolder";
            this.btnSelectSourceFolder.Size = new System.Drawing.Size(156, 28);
            this.btnSelectSourceFolder.TabIndex = 0;
            this.btnSelectSourceFolder.Text = "Select source folder";
            this.btnSelectSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectSourceFolder.Click += new System.EventHandler(this.btnSelectSourceFolder_Click);
            // 
            // tvFoundBooks
            // 
            this.tvFoundBooks.Location = new System.Drawing.Point(12, 46);
            this.tvFoundBooks.Name = "tvFoundBooks";
            this.tvFoundBooks.Size = new System.Drawing.Size(606, 293);
            this.tvFoundBooks.TabIndex = 1;
            this.tvFoundBooks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFoundBooks_AfterSelect);
            // 
            // gpFileDetails
            // 
            this.gpFileDetails.Controls.Add(this.dtLastAccessed);
            this.gpFileDetails.Controls.Add(this.dtCreated);
            this.gpFileDetails.Controls.Add(this.txtFileName);
            this.gpFileDetails.Controls.Add(this.txtFileSize);
            this.gpFileDetails.Controls.Add(this.txtFilePath);
            this.gpFileDetails.Controls.Add(this.txtExtension);
            this.gpFileDetails.Controls.Add(this.label14);
            this.gpFileDetails.Controls.Add(this.label13);
            this.gpFileDetails.Controls.Add(this.label12);
            this.gpFileDetails.Controls.Add(this.label11);
            this.gpFileDetails.Controls.Add(this.label10);
            this.gpFileDetails.Controls.Add(this.label9);
            this.gpFileDetails.Location = new System.Drawing.Point(633, 46);
            this.gpFileDetails.Name = "gpFileDetails";
            this.gpFileDetails.Size = new System.Drawing.Size(388, 250);
            this.gpFileDetails.TabIndex = 2;
            this.gpFileDetails.TabStop = false;
            this.gpFileDetails.Text = "File details";
            // 
            // dtLastAccessed
            // 
            this.dtLastAccessed.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.dtLastAccessed.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtLastAccessed.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtLastAccessed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtLastAccessed.Location = new System.Drawing.Point(139, 125);
            this.dtLastAccessed.Name = "dtLastAccessed";
            this.dtLastAccessed.Size = new System.Drawing.Size(215, 22);
            this.dtLastAccessed.TabIndex = 13;
            this.dtLastAccessed.Value = new System.DateTime(2020, 10, 30, 18, 28, 55, 0);
            // 
            // dtCreated
            // 
            this.dtCreated.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.dtCreated.CalendarTitleForeColor = System.Drawing.Color.AliceBlue;
            this.dtCreated.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCreated.Location = new System.Drawing.Point(139, 94);
            this.dtCreated.Name = "dtCreated";
            this.dtCreated.Size = new System.Drawing.Size(215, 22);
            this.dtCreated.TabIndex = 12;
            this.dtCreated.Value = new System.DateTime(2020, 10, 30, 18, 28, 55, 0);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(139, 33);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(215, 22);
            this.txtFileName.TabIndex = 11;
            // 
            // txtFileSize
            // 
            this.txtFileSize.Location = new System.Drawing.Point(139, 188);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.ReadOnly = true;
            this.txtFileSize.Size = new System.Drawing.Size(215, 22);
            this.txtFileSize.TabIndex = 10;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(139, 160);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(215, 22);
            this.txtFilePath.TabIndex = 9;
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(139, 66);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.ReadOnly = true;
            this.txtExtension.Size = new System.Drawing.Size(215, 22);
            this.txtExtension.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 17);
            this.label14.TabIndex = 5;
            this.label14.Text = "Size:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "File Path:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = "Created:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Last Accessed:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "File Extension:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "File Name:";
            // 
            // gpBoolDetails
            // 
            this.gpBoolDetails.Controls.Add(this.label16);
            this.gpBoolDetails.Controls.Add(this.label8);
            this.gpBoolDetails.Controls.Add(this.label7);
            this.gpBoolDetails.Controls.Add(this.dtDatePublished);
            this.gpBoolDetails.Controls.Add(this.label6);
            this.gpBoolDetails.Controls.Add(this.label5);
            this.gpBoolDetails.Controls.Add(this.label4);
            this.gpBoolDetails.Controls.Add(this.label3);
            this.gpBoolDetails.Controls.Add(this.label2);
            this.gpBoolDetails.Controls.Add(this.label1);
            this.gpBoolDetails.Controls.Add(this.txtClassification);
            this.gpBoolDetails.Controls.Add(this.txtCategory);
            this.gpBoolDetails.Controls.Add(this.txtISBN);
            this.gpBoolDetails.Controls.Add(this.txtPrice);
            this.gpBoolDetails.Controls.Add(this.txtPublisher);
            this.gpBoolDetails.Controls.Add(this.txtAuthor);
            this.gpBoolDetails.Controls.Add(this.txtTitle);
            this.gpBoolDetails.Controls.Add(this.btnAddBookToStorageSpace);
            this.gpBoolDetails.Location = new System.Drawing.Point(633, 302);
            this.gpBoolDetails.Name = "gpBoolDetails";
            this.gpBoolDetails.Size = new System.Drawing.Size(388, 338);
            this.gpBoolDetails.TabIndex = 3;
            this.gpBoolDetails.TabStop = false;
            this.gpBoolDetails.Text = "Book Details";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label16.Location = new System.Drawing.Point(18, 153);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 20);
            this.label16.TabIndex = 17;
            this.label16.Text = "ISBN:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label8.Location = new System.Drawing.Point(18, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Classification:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label7.Location = new System.Drawing.Point(18, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Category:";
            // 
            // dtDatePublished
            // 
            this.dtDatePublished.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.dtDatePublished.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDatePublished.Location = new System.Drawing.Point(139, 184);
            this.dtDatePublished.Name = "dtDatePublished";
            this.dtDatePublished.Size = new System.Drawing.Size(228, 22);
            this.dtDatePublished.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 7F);
            this.label6.Location = new System.Drawing.Point(19, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Date Published:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label5.Location = new System.Drawing.Point(18, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label4.Location = new System.Drawing.Point(18, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label3.Location = new System.Drawing.Point(18, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Publisher:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label2.Location = new System.Drawing.Point(18, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Author:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Title:";
            // 
            // txtClassification
            // 
            this.txtClassification.Location = new System.Drawing.Point(139, 252);
            this.txtClassification.Name = "txtClassification";
            this.txtClassification.Size = new System.Drawing.Size(228, 22);
            this.txtClassification.TabIndex = 8;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(139, 219);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(228, 22);
            this.txtCategory.TabIndex = 7;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(139, 153);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(228, 22);
            this.txtISBN.TabIndex = 5;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(139, 120);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(228, 22);
            this.txtPrice.TabIndex = 4;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(139, 87);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(228, 22);
            this.txtPublisher.TabIndex = 3;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(139, 54);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(228, 22);
            this.txtAuthor.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(139, 21);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(228, 22);
            this.txtTitle.TabIndex = 1;
            // 
            // btnAddBookToStorageSpace
            // 
            this.btnAddBookToStorageSpace.Location = new System.Drawing.Point(297, 280);
            this.btnAddBookToStorageSpace.Name = "btnAddBookToStorageSpace";
            this.btnAddBookToStorageSpace.Size = new System.Drawing.Size(47, 23);
            this.btnAddBookToStorageSpace.TabIndex = 0;
            this.btnAddBookToStorageSpace.Text = "Add";
            this.btnAddBookToStorageSpace.UseVisualStyleBackColor = true;
            this.btnAddBookToStorageSpace.Click += new System.EventHandler(this.btnAddBookToStorageSpace_Click);
            // 
            // dbVirtalStorageSpace
            // 
            this.dbVirtalStorageSpace.Controls.Add(this.lblEbookCount);
            this.dbVirtalStorageSpace.Controls.Add(this.lblStorageSpaceDescription);
            this.dbVirtalStorageSpace.Controls.Add(this.txtStorageSpaceDescription);
            this.dbVirtalStorageSpace.Controls.Add(this.btnCancelNewStorageSpaceSave);
            this.dbVirtalStorageSpace.Controls.Add(this.btnSaveNewStorageSpace);
            this.dbVirtalStorageSpace.Controls.Add(this.txtNewStorageSpaceName);
            this.dbVirtalStorageSpace.Controls.Add(this.btnAddNewStorageSpace);
            this.dbVirtalStorageSpace.Controls.Add(this.dlVirtualStorageSpaces);
            this.dbVirtalStorageSpace.Location = new System.Drawing.Point(12, 345);
            this.dbVirtalStorageSpace.Name = "dbVirtalStorageSpace";
            this.dbVirtalStorageSpace.Size = new System.Drawing.Size(606, 295);
            this.dbVirtalStorageSpace.TabIndex = 4;
            this.dbVirtalStorageSpace.TabStop = false;
            this.dbVirtalStorageSpace.Text = "Virtual storage spaces";
            // 
            // lblEbookCount
            // 
            this.lblEbookCount.AutoSize = true;
            this.lblEbookCount.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.lblEbookCount.Location = new System.Drawing.Point(6, 68);
            this.lblEbookCount.Name = "lblEbookCount";
            this.lblEbookCount.Size = new System.Drawing.Size(154, 20);
            this.lblEbookCount.TabIndex = 13;
            this.lblEbookCount.Text = "Label eBook Count: ";
            // 
            // lblStorageSpaceDescription
            // 
            this.lblStorageSpaceDescription.AutoSize = true;
            this.lblStorageSpaceDescription.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.lblStorageSpaceDescription.Location = new System.Drawing.Point(316, 87);
            this.lblStorageSpaceDescription.Name = "lblStorageSpaceDescription";
            this.lblStorageSpaceDescription.Size = new System.Drawing.Size(203, 20);
            this.lblStorageSpaceDescription.TabIndex = 12;
            this.lblStorageSpaceDescription.Text = "Storage Space Description";
            // 
            // txtStorageSpaceDescription
            // 
            this.txtStorageSpaceDescription.Location = new System.Drawing.Point(315, 110);
            this.txtStorageSpaceDescription.Multiline = true;
            this.txtStorageSpaceDescription.Name = "txtStorageSpaceDescription";
            this.txtStorageSpaceDescription.ReadOnly = true;
            this.txtStorageSpaceDescription.Size = new System.Drawing.Size(258, 144);
            this.txtStorageSpaceDescription.TabIndex = 11;
            // 
            // btnCancelNewStorageSpaceSave
            // 
            this.btnCancelNewStorageSpaceSave.Location = new System.Drawing.Point(525, 21);
            this.btnCancelNewStorageSpaceSave.Name = "btnCancelNewStorageSpaceSave";
            this.btnCancelNewStorageSpaceSave.Size = new System.Drawing.Size(75, 25);
            this.btnCancelNewStorageSpaceSave.TabIndex = 5;
            this.btnCancelNewStorageSpaceSave.Text = "cancel";
            this.btnCancelNewStorageSpaceSave.UseVisualStyleBackColor = true;
            this.btnCancelNewStorageSpaceSave.Visible = false;
            this.btnCancelNewStorageSpaceSave.Click += new System.EventHandler(this.btnCancelNewStorageSpaceSave_Click);
            // 
            // btnSaveNewStorageSpace
            // 
            this.btnSaveNewStorageSpace.Location = new System.Drawing.Point(461, 21);
            this.btnSaveNewStorageSpace.Name = "btnSaveNewStorageSpace";
            this.btnSaveNewStorageSpace.Size = new System.Drawing.Size(58, 25);
            this.btnSaveNewStorageSpace.TabIndex = 3;
            this.btnSaveNewStorageSpace.Text = "save";
            this.btnSaveNewStorageSpace.UseVisualStyleBackColor = true;
            this.btnSaveNewStorageSpace.Visible = false;
            this.btnSaveNewStorageSpace.Click += new System.EventHandler(this.btnSaveNewStorageSpace_Click);
            // 
            // txtNewStorageSpaceName
            // 
            this.txtNewStorageSpaceName.Location = new System.Drawing.Point(279, 23);
            this.txtNewStorageSpaceName.Name = "txtNewStorageSpaceName";
            this.txtNewStorageSpaceName.Size = new System.Drawing.Size(175, 22);
            this.txtNewStorageSpaceName.TabIndex = 2;
            this.txtNewStorageSpaceName.Visible = false;
            // 
            // btnAddNewStorageSpace
            // 
            this.btnAddNewStorageSpace.Location = new System.Drawing.Point(213, 21);
            this.btnAddNewStorageSpace.Name = "btnAddNewStorageSpace";
            this.btnAddNewStorageSpace.Size = new System.Drawing.Size(49, 25);
            this.btnAddNewStorageSpace.TabIndex = 1;
            this.btnAddNewStorageSpace.Text = "Add";
            this.btnAddNewStorageSpace.UseVisualStyleBackColor = true;
            this.btnAddNewStorageSpace.Click += new System.EventHandler(this.btnAddNewStorageSpace_Click);
            // 
            // dlVirtualStorageSpaces
            // 
            this.dlVirtualStorageSpaces.FormattingEnabled = true;
            this.dlVirtualStorageSpaces.Location = new System.Drawing.Point(7, 22);
            this.dlVirtualStorageSpaces.Name = "dlVirtualStorageSpaces";
            this.dlVirtualStorageSpaces.Size = new System.Drawing.Size(199, 24);
            this.dlVirtualStorageSpaces.TabIndex = 0;
            this.dlVirtualStorageSpaces.SelectedIndexChanged += new System.EventHandler(this.dlVirtualStorageSpaces_SelectedIndexChanged);
            // 
            // ImportBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 652);
            this.Controls.Add(this.dbVirtalStorageSpace);
            this.Controls.Add(this.gpBoolDetails);
            this.Controls.Add(this.gpFileDetails);
            this.Controls.Add(this.tvFoundBooks);
            this.Controls.Add(this.btnSelectSourceFolder);
            this.Name = "ImportBooks";
            this.Text = "ImportBooks";
            this.Load += new System.EventHandler(this.ImportBooks_Load);
            this.gpFileDetails.ResumeLayout(false);
            this.gpFileDetails.PerformLayout();
            this.gpBoolDetails.ResumeLayout(false);
            this.gpBoolDetails.PerformLayout();
            this.dbVirtalStorageSpace.ResumeLayout(false);
            this.dbVirtalStorageSpace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectSourceFolder;
        private System.Windows.Forms.TreeView tvFoundBooks;
        private System.Windows.Forms.GroupBox gpFileDetails;
        private System.Windows.Forms.GroupBox gpBoolDetails;
        private System.Windows.Forms.GroupBox dbVirtalStorageSpace;
        private System.Windows.Forms.Button btnSaveNewStorageSpace;
        private System.Windows.Forms.TextBox txtNewStorageSpaceName;
        private System.Windows.Forms.Button btnAddNewStorageSpace;
        private System.Windows.Forms.ComboBox dlVirtualStorageSpaces;
        private System.Windows.Forms.Button btnCancelNewStorageSpaceSave;
        private System.Windows.Forms.Button btnAddBookToStorageSpace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtDatePublished;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassification;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.DateTimePicker dtLastAccessed;
        private System.Windows.Forms.DateTimePicker dtCreated;
        private System.Windows.Forms.Label lblStorageSpaceDescription;
        private System.Windows.Forms.TextBox txtStorageSpaceDescription;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblEbookCount;
    }
}