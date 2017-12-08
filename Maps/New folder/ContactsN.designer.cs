namespace Protocol
{
    partial class ContactsN
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactsN));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SearchText3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SearchText2 = new System.Windows.Forms.TextBox();
            this.SearchText1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchText0 = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.προβολήToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.επιλογήToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.έξοδοςToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textSelectedMails = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterExactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.export2ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelFiller = new System.Windows.Forms.TextBox();
            this.contactsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.contactsTableAdapter = new Protocol._GramV3_DevDataSet_ContactTableAdapters.ContactsTableAdapter();
            this.updateKeyTableAdapter = new Protocol._GramV3_DevDataSet_ContactTableAdapters.UpdateKeyTableAdapter();
            this.tableAdapterManager = new Protocol._GramV3_DevDataSet_ContactTableAdapters.TableAdapterManager();
            this.viewDistCompanyTableAdapter = new Protocol._GramV3_DevDataSet_ContactTableAdapters.ViewDistCompanyTableAdapter();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 41);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SearchText3);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.SearchText2);
            this.panel3.Controls.Add(this.SearchText1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.SearchText0);
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(766, 40);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // SearchText3
            // 
            this.SearchText3.Location = new System.Drawing.Point(608, 8);
            this.SearchText3.Name = "SearchText3";
            this.SearchText3.Size = new System.Drawing.Size(105, 20);
            this.SearchText3.TabIndex = 26;
            this.SearchText3.Tag = "email";
            this.SearchText3.Enter += new System.EventHandler(this.SearchText_Enter);
            this.SearchText3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTextKeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(560, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "email";
            // 
            // SearchText2
            // 
            this.SearchText2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SearchText2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchText2.Location = new System.Drawing.Point(435, 8);
            this.SearchText2.Name = "SearchText2";
            this.SearchText2.Size = new System.Drawing.Size(105, 20);
            this.SearchText2.TabIndex = 24;
            this.SearchText2.Tag = "Company";
            this.SearchText2.Enter += new System.EventHandler(this.SearchText_Enter);
            this.SearchText2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTextKeyUp);
            // 
            // SearchText1
            // 
            this.SearchText1.Location = new System.Drawing.Point(266, 8);
            this.SearchText1.Name = "SearchText1";
            this.SearchText1.Size = new System.Drawing.Size(107, 20);
            this.SearchText1.TabIndex = 23;
            this.SearchText1.Tag = "FirstName";
            this.SearchText1.Enter += new System.EventHandler(this.SearchText_Enter);
            this.SearchText1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTextKeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Εταιρία";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Όνομα";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Επώνυμο";
            // 
            // SearchText0
            // 
            this.SearchText0.Location = new System.Drawing.Point(87, 8);
            this.SearchText0.Name = "SearchText0";
            this.SearchText0.Size = new System.Drawing.Size(103, 20);
            this.SearchText0.TabIndex = 19;
            this.SearchText0.Tag = "LastName";
            this.SearchText0.Enter += new System.EventHandler(this.SearchText_Enter);
            this.SearchText0.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTextKeyUp);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.προβολήToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.postToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.επιλογήToolStripMenuItem,
            this.έξοδοςToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(769, 29);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(95, 25);
            this.addToolStripMenuItem.Tag = "Browse";
            this.addToolStripMenuItem.Text = "Προσθήκη";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // προβολήToolStripMenuItem
            // 
            this.προβολήToolStripMenuItem.Name = "προβολήToolStripMenuItem";
            this.προβολήToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.προβολήToolStripMenuItem.Tag = "Browse";
            this.προβολήToolStripMenuItem.Text = "Προβολή";
            this.προβολήToolStripMenuItem.Click += new System.EventHandler(this.προβολήToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(96, 25);
            this.updateToolStripMenuItem.Tag = "Browse";
            this.updateToolStripMenuItem.Text = "Μεταβολή";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(93, 25);
            this.deleteToolStripMenuItem.Tag = "Browse";
            this.deleteToolStripMenuItem.Text = "Διαγραφή";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // postToolStripMenuItem
            // 
            this.postToolStripMenuItem.Image = global::Protocol.Properties.Resources.Save_32x;
            this.postToolStripMenuItem.Name = "postToolStripMenuItem";
            this.postToolStripMenuItem.Size = new System.Drawing.Size(119, 25);
            this.postToolStripMenuItem.Tag = "Update";
            this.postToolStripMenuItem.Text = "Ενημέρωση";
            this.postToolStripMenuItem.Click += new System.EventHandler(this.postToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::Protocol.Properties.Resources.Cancel_32x;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.cancelToolStripMenuItem.Tag = "Update";
            this.cancelToolStripMenuItem.Text = "Ακύρωση";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // επιλογήToolStripMenuItem
            // 
            this.επιλογήToolStripMenuItem.Name = "επιλογήToolStripMenuItem";
            this.επιλογήToolStripMenuItem.Size = new System.Drawing.Size(78, 25);
            this.επιλογήToolStripMenuItem.Tag = "Browse";
            this.επιλογήToolStripMenuItem.Text = "Επιλογή";
            this.επιλογήToolStripMenuItem.Click += new System.EventHandler(this.επιλογήToolStripMenuItem_Click);
            // 
            // έξοδοςToolStripMenuItem
            // 
            this.έξοδοςToolStripMenuItem.Name = "έξοδοςToolStripMenuItem";
            this.έξοδοςToolStripMenuItem.Size = new System.Drawing.Size(72, 25);
            this.έξοδοςToolStripMenuItem.Tag = "Selection";
            this.έξοδοςToolStripMenuItem.Text = "Έξοδος";
            this.έξοδοςToolStripMenuItem.Click += new System.EventHandler(this.έξοδοςToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 587);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(769, 587);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textSelectedMails);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(761, 561);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "List";
            // 
            // textSelectedMails
            // 
            this.textSelectedMails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textSelectedMails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSelectedMails.Location = new System.Drawing.Point(3, 514);
            this.textSelectedMails.MaximumSize = new System.Drawing.Size(755, 44);
            this.textSelectedMails.MinimumSize = new System.Drawing.Size(755, 44);
            this.textSelectedMails.Name = "textSelectedMails";
            this.textSelectedMails.ReadOnly = true;
            this.textSelectedMails.Size = new System.Drawing.Size(755, 44);
            this.textSelectedMails.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Size = new System.Drawing.Size(755, 555);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem,
            this.filterOnlyToolStripMenuItem,
            this.filterExactToolStripMenuItem,
            this.export2ExcelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // filterOnlyToolStripMenuItem
            // 
            this.filterOnlyToolStripMenuItem.Name = "filterOnlyToolStripMenuItem";
            this.filterOnlyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.filterOnlyToolStripMenuItem.Text = "Clear Filter";
            this.filterOnlyToolStripMenuItem.Click += new System.EventHandler(this.filterOnlyToolStripMenuItem_Click);
            // 
            // filterExactToolStripMenuItem
            // 
            this.filterExactToolStripMenuItem.Name = "filterExactToolStripMenuItem";
            this.filterExactToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.filterExactToolStripMenuItem.Text = "Filter Exact";
            this.filterExactToolStripMenuItem.Click += new System.EventHandler(this.filterExactToolStripMenuItem_Click);
            // 
            // export2ExcelToolStripMenuItem
            // 
            this.export2ExcelToolStripMenuItem.Name = "export2ExcelToolStripMenuItem";
            this.export2ExcelToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.export2ExcelToolStripMenuItem.Text = "Export2Excel";
            this.export2ExcelToolStripMenuItem.Click += new System.EventHandler(this.export2ExcelToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(761, 561);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Detail";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelFiller);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(755, 555);
            this.panel4.TabIndex = 0;
            // 
            // labelFiller
            // 
            this.labelFiller.Location = new System.Drawing.Point(604, 16);
            this.labelFiller.Name = "labelFiller";
            this.labelFiller.Size = new System.Drawing.Size(1, 20);
            this.labelFiller.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // contactsTableAdapter
            // 
            this.contactsTableAdapter.ClearBeforeFill = true;
            // 
            // updateKeyTableAdapter
            // 
            this.updateKeyTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.ContactsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Protocol._GramV3_DevDataSet_ContactTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // viewDistCompanyTableAdapter
            // 
            this.viewDistCompanyTableAdapter.ClearBeforeFill = true;
            // 
            // ContactsN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 657);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ContactsN";
            this.Text = "Διευθυνσιογράφος";
            this.Load += new System.EventHandler(this.Contacts_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.BindingSource contactsBindingSource;
        private _GramV3_DevDataSet_ContactTableAdapters.ContactsTableAdapter contactsTableAdapter;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterExactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem export2ExcelToolStripMenuItem;
        private _GramV3_DevDataSet_ContactTableAdapters.UpdateKeyTableAdapter updateKeyTableAdapter;
        private _GramV3_DevDataSet_ContactTableAdapters.TableAdapterManager tableAdapterManager;
        private _GramV3_DevDataSet_ContactTableAdapters.ViewDistCompanyTableAdapter viewDistCompanyTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem επιλογήToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem έξοδοςToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox SearchText3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SearchText2;
        private System.Windows.Forms.TextBox SearchText1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchText0;
        private System.Windows.Forms.ToolStripMenuItem προβολήToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox labelFiller;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textSelectedMails;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}