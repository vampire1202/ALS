namespace ALS.FormOperation
{
    partial class ucWarnInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.dgvView = new ALS.DataGridViewExs.DataGridViewEx();
            this.databasegrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new ALS.DataGridViewExs.ColumnEx.DataGridViewButtonColumnEx();
            this.btnReleaseWarn = new PulseButton.PulseButton();
            this.btnMute = new PulseButton.PulseButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tomato;
            this.panel1.Controls.Add(this.btnMute);
            this.panel1.Controls.Add(this.btnReleaseWarn);
            this.panel1.Controls.Add(this.bindingNavigator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 42);
            this.panel1.TabIndex = 1;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bindingNavigator1.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bindingNavigator1.Size = new System.Drawing.Size(205, 54);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.Visible = false;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AutoSize = false;
            this.bindingNavigatorMoveFirstItem.BackColor = System.Drawing.Color.Gold;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveFirstItem.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(48, 51);
            this.bindingNavigatorMoveFirstItem.Text = "第一条";
            this.bindingNavigatorMoveFirstItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bindingNavigatorMoveFirstItem.ToolTipText = "第一条";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AutoSize = false;
            this.bindingNavigatorMovePreviousItem.BackColor = System.Drawing.Color.Khaki;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMovePreviousItem.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(48, 51);
            this.bindingNavigatorMovePreviousItem.Text = "上一条";
            this.bindingNavigatorMovePreviousItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AutoSize = false;
            this.bindingNavigatorMoveNextItem.BackColor = System.Drawing.Color.Khaki;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveNextItem.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(48, 51);
            this.bindingNavigatorMoveNextItem.Text = "下一条";
            this.bindingNavigatorMoveNextItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AutoSize = false;
            this.bindingNavigatorMoveLastItem.BackColor = System.Drawing.Color.Gold;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(48, 51);
            this.bindingNavigatorMoveLastItem.Text = "最后一条";
            this.bindingNavigatorMoveLastItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            this.dgvView.AllowUserToResizeColumns = false;
            this.dgvView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.databasegrade,
            this.grade,
            this.code,
            this.name,
            this.reason,
            this.deal,
            this.Column5});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvView.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(0, 42);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvView.RowHeadersVisible = false;
            this.dgvView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dgvView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvView.RowTemplate.DividerHeight = 60;
            this.dgvView.RowTemplate.Height = 120;
            this.dgvView.RowTemplate.ReadOnly = true;
            this.dgvView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(399, 496);
            this.dgvView.TabIndex = 3;
            this.dgvView.CellButtonClicked += new ALS.DataGridViewExs.EventsEx.DataGridViewButtonClicked(this.dgvView_CellButtonClicked);
            // 
            // databasegrade
            // 
            this.databasegrade.Frozen = true;
            this.databasegrade.HeaderText = "存储等级";
            this.databasegrade.Name = "databasegrade";
            this.databasegrade.ReadOnly = true;
            this.databasegrade.Visible = false;
            // 
            // grade
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grade.DefaultCellStyle = dataGridViewCellStyle2;
            this.grade.Frozen = true;
            this.grade.HeaderText = "等级";
            this.grade.MinimumWidth = 30;
            this.grade.Name = "grade";
            this.grade.ReadOnly = true;
            this.grade.Width = 30;
            // 
            // code
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.code.DefaultCellStyle = dataGridViewCellStyle3;
            this.code.Frozen = true;
            this.code.HeaderText = "代码";
            this.code.MinimumWidth = 45;
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.code.Width = 45;
            // 
            // name
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.name.DefaultCellStyle = dataGridViewCellStyle4;
            this.name.Frozen = true;
            this.name.HeaderText = "名称";
            this.name.MinimumWidth = 60;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name.Width = 60;
            // 
            // reason
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.reason.DefaultCellStyle = dataGridViewCellStyle5;
            this.reason.HeaderText = "发生条件";
            this.reason.MinimumWidth = 74;
            this.reason.Name = "reason";
            this.reason.ReadOnly = true;
            this.reason.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.reason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.reason.Width = 74;
            // 
            // deal
            // 
            this.deal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.deal.DefaultCellStyle = dataGridViewCellStyle6;
            this.deal.HeaderText = "处理方式";
            this.deal.MinimumWidth = 120;
            this.deal.Name = "deal";
            this.deal.ReadOnly = true;
            this.deal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.ButtonBgColor = System.Drawing.Color.SteelBlue;
            this.Column5.ButtonSize = new System.Drawing.Size(50, 30);
            this.Column5.ButtonText = "消除";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Column5.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column5.HeaderText = "";
            this.Column5.MinimumWidth = 50;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // btnReleaseWarn
            // 
            this.btnReleaseWarn.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.btnReleaseWarn.ButtonColorTop = System.Drawing.Color.Honeydew;
            this.btnReleaseWarn.CornerRadius = 20;
            this.btnReleaseWarn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReleaseWarn.FocusColor = System.Drawing.Color.Black;
            this.btnReleaseWarn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnReleaseWarn.ForeColor = System.Drawing.Color.Black;
            this.btnReleaseWarn.Image = global::ALS.Properties.Resources.releasewarn;
            this.btnReleaseWarn.Location = new System.Drawing.Point(305, 0);
            this.btnReleaseWarn.Name = "btnReleaseWarn";
            this.btnReleaseWarn.PulseColor = System.Drawing.Color.DimGray;
            this.btnReleaseWarn.PulseSpeed = 0.3F;
            this.btnReleaseWarn.PulseWidth = 1;
            this.btnReleaseWarn.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnReleaseWarn.Size = new System.Drawing.Size(94, 42);
            this.btnReleaseWarn.TabIndex = 122;
            this.btnReleaseWarn.Text = "报警\r\n复位";
            this.btnReleaseWarn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReleaseWarn.UseVisualStyleBackColor = true;
            this.btnReleaseWarn.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnMute
            // 
            this.btnMute.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnMute.ButtonColorTop = System.Drawing.Color.White;
            this.btnMute.CornerRadius = 20;
            this.btnMute.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMute.FocusColor = System.Drawing.Color.Black;
            this.btnMute.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnMute.ForeColor = System.Drawing.Color.Black;
            this.btnMute.Image = global::ALS.Properties.Resources.mute;
            this.btnMute.Location = new System.Drawing.Point(215, 0);
            this.btnMute.Name = "btnMute";
            this.btnMute.PulseColor = System.Drawing.Color.DimGray;
            this.btnMute.PulseSpeed = 0.3F;
            this.btnMute.PulseWidth = 1;
            this.btnMute.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnMute.Size = new System.Drawing.Size(90, 42);
            this.btnMute.TabIndex = 122;
            this.btnMute.Text = "声音\r\n暂停";
            this.btnMute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // ucWarnInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.panel1);
            this.Name = "ucWarnInfo";
            this.Size = new System.Drawing.Size(399, 538);
            this.Load += new System.EventHandler(this.ucWarnInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        public DataGridViewExs.DataGridViewEx dgvView;
        private System.Windows.Forms.DataGridViewTextBoxColumn databasegrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn deal;
        private DataGridViewExs.ColumnEx.DataGridViewButtonColumnEx Column5;
        public PulseButton.PulseButton btnMute;
        public PulseButton.PulseButton btnReleaseWarn;
    }
}
