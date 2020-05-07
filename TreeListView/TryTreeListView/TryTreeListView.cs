using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace TryTreeListView
{
    
    /// <summary>
    /// Summary description for TryTreeListView.
    /// </summary>
    public class TryTreeListView : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeListView treeListView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.ComponentModel.IContainer components;

		public TryTreeListView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TryTreeListView));
			this.treeListView1 = new System.Windows.Forms.TreeListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeListView1
			// 
			this.treeListView1.AllowColumnReorder = true;
			treeListView1.UseCustomDrawHeader = true;
			this.treeListView1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.treeListView1.CheckBoxes = System.Windows.Forms.CheckBoxesTypes.Recursive;
			this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.columnHeader1,
																							this.columnHeader2,
																							this.columnHeader3});
			this.treeListView1.HideSelection = false;
			this.treeListView1.LabelEdit = true;
			this.treeListView1.Location = new System.Drawing.Point(4, 4);
			this.treeListView1.Name = "treeListView1";
			this.treeListView1.Size = new System.Drawing.Size(392, 180);
			this.treeListView1.SmallImageList = this.imageList1;
			this.treeListView1.TabIndex = 0;
            this.treeListView1.ShowPlusMinus = true;
			this.treeListView1.BeforeLabelEdit += new System.Windows.Forms.TreeListViewBeforeLabelEditEventHandler(this.treeListView1_BeforeLabelEdit);
			this.treeListView1.BeforeCollapse += new System.Windows.Forms.TreeListViewCancelEventHandler(this.treeListView1_BeforeCollapse);
			this.treeListView1.BeforeExpand += new System.Windows.Forms.TreeListViewCancelEventHandler(this.treeListView1_BeforeExpand);

			treeListView1.OwnerDraw = true;
			

			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 200;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Attribute";
			this.columnHeader2.Width = 100;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// button1
			// 
			this.button1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(8, 192);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Add / Remove All";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(264, 192);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Expand / Collapse All";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// TryTreeListView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 219);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.button1,
																		  this.treeListView1});
			this.Name = "TryTreeListView";
			this.Text = "TryTreeListView";
			this.Load += new System.EventHandler(this.TryTreeListView_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new TryTreeListView());
		}

		private void TryTreeListView_Load(object sender, System.EventArgs e)
		{
			AddItems();
		}

		private void treeListView1_BeforeExpand(object sender, System.Windows.Forms.TreeListViewCancelEventArgs e)
		{
			if(e.Item.ImageIndex == 1) e.Item.ImageIndex = 2;
		}

		private void treeListView1_BeforeCollapse(object sender, System.Windows.Forms.TreeListViewCancelEventArgs e)
		{
			if(e.Item.ImageIndex == 2) e.Item.ImageIndex = 1;
		}

		private void treeListView1_BeforeLabelEdit(object sender, System.Windows.Forms.TreeListViewBeforeLabelEditEventArgs e)
		{
			if(e.Item.ImageIndex < 1 || e.Item.ImageIndex > 2)
				e.ColumnIndex = 0;
			if(e.ColumnIndex == 1)
			{
				ComboBox combobox = new ComboBox();
				combobox.Items.AddRange(new string[]{"New value 1","New value 2","New value 3"});
				e.Editor = combobox;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(treeListView1.Items.Count > 0)
				treeListView1.Items.Clear();
			else
				AddItems();
		}

		bool collapse = false;
		private void button2_Click(object sender, System.EventArgs e)
		{
			if(collapse) treeListView1.CollapseAll();
			else treeListView1.ExpandAll();
			collapse = !collapse;
		}

		private void AddItems()
		{
			

            var ic = new TreeListViewItem("XXX", 0);
            var ic1 = new TreeListViewItem("XXy", 0);

            var ic2 = new TreeListViewItem("XXz", 0);

			var myCustomSubItem = new TreeListViewSubItem()
			{
				Text = "Text",
				UseGradientBackground = true,
				BackgroundGradientStartColor = Color.Red,
				FillRatio = .6,
			};

			ic1.SubItems.Add(myCustomSubItem);

            ic1.SubItems.Add(new Button2Item("r ic1"));
            
            ic.SubItems.Add(new Button2Item("r ic"));

            ic.Items.Add(ic1);
            ic1.Items.Add(ic2);
            treeListView1.Items.Add(ic);
            
            var h2 = new TreeListViewItem("new Hierarchy", 0);
            h2.SubItems.Add("neinteresant");
            h2.SubItems.Add(new Button2Item("inca unu"));
            treeListView1.Items.Add(h2);
        }
	
		private enum DrivesDescr{First, Second, Third, Fourth}
		private enum Drives{C, D, E, Z}
	}

    public class ButtonItem : TreeListViewItem, IControlWrappedItem
    {
        Button _b = new Button() { Text = "Push me" };
        public Control Control { get => _b; set => throw new NotImplementedException(); }
        public ButtonItem()
        {
            _b.Visible = false;
            _b.Click += (sender, e) =>
            {
                MessageBox.Show("Hello dude.");
            };
        }
    }

    public class Button2Item : ListViewSubItem, IControlWrappedItem
    {
        Button _b = new Button() { Text = "Push me too" };
        public Control Control { get => _b; set => throw new NotImplementedException(); }
        public Button2Item(string label)
        {
            _b.FlatStyle = FlatStyle.System;
            _b.Text = label;
            _b.Visible = false;
            _b.Click += (sender, e) =>
            {
                MessageBox.Show("Hello dude from 2.");
            };
        }
    }
}
