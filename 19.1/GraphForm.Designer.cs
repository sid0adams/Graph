namespace _19._1
{
    partial class GraphForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OutputA = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenA = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenB = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveA = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveB = new System.Windows.Forms.ToolStripMenuItem();
            this.задачаКитайскогоПочтальёнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CPP_A_Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.CPP_B_BTN = new System.Windows.Forms.ToolStripMenuItem();
            this.OutputB = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ChangeBtn = new System.Windows.Forms.RadioButton();
            this.AddBtn = new System.Windows.Forms.RadioButton();
            this.AddEdge = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeContextBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.IsomorfBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.EdgeParam = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.OutputA)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutputB)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputA
            // 
            this.OutputA.Location = new System.Drawing.Point(12, 79);
            this.OutputA.Margin = new System.Windows.Forms.Padding(2);
            this.OutputA.Name = "OutputA";
            this.OutputA.Size = new System.Drawing.Size(691, 534);
            this.OutputA.TabIndex = 0;
            this.OutputA.TabStop = false;
            this.OutputA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Output_MouseDown);
            this.OutputA.MouseLeave += new System.EventHandler(this.Output_MouseLeave);
            this.OutputA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Output_MouseMove);
            this.OutputA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Output_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.задачаКитайскогоПочтальёнаToolStripMenuItem,
            this.IsomorfBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1408, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenA,
            this.OpenB});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.открытьToolStripMenuItem.Text = "открыть ";
            // 
            // OpenA
            // 
            this.OpenA.Name = "OpenA";
            this.OpenA.Size = new System.Drawing.Size(82, 22);
            this.OpenA.Text = "A";
            this.OpenA.Click += new System.EventHandler(this.Open_Click);
            // 
            // OpenB
            // 
            this.OpenB.Name = "OpenB";
            this.OpenB.Size = new System.Drawing.Size(82, 22);
            this.OpenB.Text = "B";
            this.OpenB.Click += new System.EventHandler(this.Open_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveA,
            this.SaveB});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.сохранитьToolStripMenuItem.Text = "сохранить";
            // 
            // SaveA
            // 
            this.SaveA.Name = "SaveA";
            this.SaveA.Size = new System.Drawing.Size(82, 22);
            this.SaveA.Text = "A";
            this.SaveA.Click += new System.EventHandler(this.Save_Click);
            // 
            // SaveB
            // 
            this.SaveB.Name = "SaveB";
            this.SaveB.Size = new System.Drawing.Size(82, 22);
            this.SaveB.Text = "B";
            this.SaveB.Click += new System.EventHandler(this.Save_Click);
            // 
            // задачаКитайскогоПочтальёнаToolStripMenuItem
            // 
            this.задачаКитайскогоПочтальёнаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CPP_A_Btn,
            this.CPP_B_BTN});
            this.задачаКитайскогоПочтальёнаToolStripMenuItem.Name = "задачаКитайскогоПочтальёнаToolStripMenuItem";
            this.задачаКитайскогоПочтальёнаToolStripMenuItem.Size = new System.Drawing.Size(188, 20);
            this.задачаКитайскогоПочтальёнаToolStripMenuItem.Text = "задача китайского почтальона";
            // 
            // CPP_A_Btn
            // 
            this.CPP_A_Btn.Name = "CPP_A_Btn";
            this.CPP_A_Btn.Size = new System.Drawing.Size(82, 22);
            this.CPP_A_Btn.Text = "A";
            this.CPP_A_Btn.Click += new System.EventHandler(this.CPP_Btn_Click);
            // 
            // CPP_B_BTN
            // 
            this.CPP_B_BTN.Name = "CPP_B_BTN";
            this.CPP_B_BTN.Size = new System.Drawing.Size(82, 22);
            this.CPP_B_BTN.Text = "B";
            this.CPP_B_BTN.Click += new System.EventHandler(this.CPP_Btn_Click);
            // 
            // OutputB
            // 
            this.OutputB.Location = new System.Drawing.Point(707, 79);
            this.OutputB.Margin = new System.Windows.Forms.Padding(2);
            this.OutputB.Name = "OutputB";
            this.OutputB.Size = new System.Drawing.Size(691, 534);
            this.OutputB.TabIndex = 5;
            this.OutputB.TabStop = false;
            this.OutputB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Output_MouseDown);
            this.OutputB.MouseLeave += new System.EventHandler(this.Output_MouseLeave);
            this.OutputB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Output_MouseMove);
            this.OutputB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Output_MouseUp);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "граф (*.dat)|*.dat|все файлы|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "граф (*.dat)|*.dat|все файлы|*.*";
            // 
            // ChangeBtn
            // 
            this.ChangeBtn.AutoSize = true;
            this.ChangeBtn.Checked = true;
            this.ChangeBtn.Location = new System.Drawing.Point(12, 48);
            this.ChangeBtn.Name = "ChangeBtn";
            this.ChangeBtn.Size = new System.Drawing.Size(74, 17);
            this.ChangeBtn.TabIndex = 6;
            this.ChangeBtn.TabStop = true;
            this.ChangeBtn.Text = "изменить";
            this.ChangeBtn.UseVisualStyleBackColor = true;
            this.ChangeBtn.CheckedChanged += new System.EventHandler(this.Btn_CheckedChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.AutoSize = true;
            this.AddBtn.Location = new System.Drawing.Point(92, 48);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(98, 17);
            this.AddBtn.TabIndex = 7;
            this.AddBtn.Text = "добавить ноду";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.CheckedChanged += new System.EventHandler(this.Btn_CheckedChanged);
            // 
            // AddEdge
            // 
            this.AddEdge.AutoSize = true;
            this.AddEdge.Location = new System.Drawing.Point(196, 48);
            this.AddEdge.Name = "AddEdge";
            this.AddEdge.Size = new System.Drawing.Size(104, 17);
            this.AddEdge.TabIndex = 8;
            this.AddEdge.Text = "добавить грань";
            this.AddEdge.UseVisualStyleBackColor = true;
            this.AddEdge.CheckedChanged += new System.EventHandler(this.Btn_CheckedChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeContextBtn,
            this.RemoveBtn});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(127, 48);
            // 
            // changeContextBtn
            // 
            this.changeContextBtn.Name = "changeContextBtn";
            this.changeContextBtn.Size = new System.Drawing.Size(126, 22);
            this.changeContextBtn.Text = "изменить";
            this.changeContextBtn.Click += new System.EventHandler(this.ChangeContextBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(126, 22);
            this.RemoveBtn.Text = "удалить";
            this.RemoveBtn.Click += new System.EventHandler(this.Remove);
            // 
            // IsomorfBtn
            // 
            this.IsomorfBtn.Name = "IsomorfBtn";
            this.IsomorfBtn.Size = new System.Drawing.Size(101, 20);
            this.IsomorfBtn.Text = "изоморфность";
            this.IsomorfBtn.Click += new System.EventHandler(this.IsomorfBtn_Click);
            // 
            // EdgeParam
            // 
            this.EdgeParam.AutoSize = true;
            this.EdgeParam.Checked = true;
            this.EdgeParam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EdgeParam.Location = new System.Drawing.Point(307, 48);
            this.EdgeParam.Name = "EdgeParam";
            this.EdgeParam.Size = new System.Drawing.Size(127, 17);
            this.EdgeParam.TabIndex = 9;
            this.EdgeParam.Text = "показать вес рёбер";
            this.EdgeParam.UseVisualStyleBackColor = true;
            this.EdgeParam.CheckedChanged += new System.EventHandler(this.EdgeParam_CheckedChanged);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 624);
            this.Controls.Add(this.EdgeParam);
            this.Controls.Add(this.AddEdge);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.ChangeBtn);
            this.Controls.Add(this.OutputB);
            this.Controls.Add(this.OutputA);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GraphForm";
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.GraphForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OutputA)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutputB)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OutputA;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenA;
        private System.Windows.Forms.ToolStripMenuItem OpenB;
        private System.Windows.Forms.ToolStripMenuItem SaveA;
        private System.Windows.Forms.ToolStripMenuItem SaveB;
        private System.Windows.Forms.PictureBox OutputB;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RadioButton ChangeBtn;
        private System.Windows.Forms.RadioButton AddBtn;
        private System.Windows.Forms.RadioButton AddEdge;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changeContextBtn;
        private System.Windows.Forms.ToolStripMenuItem RemoveBtn;
        private System.Windows.Forms.ToolStripMenuItem задачаКитайскогоПочтальёнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CPP_A_Btn;
        private System.Windows.Forms.ToolStripMenuItem CPP_B_BTN;
        private System.Windows.Forms.ToolStripMenuItem IsomorfBtn;
        private System.Windows.Forms.CheckBox EdgeParam;
    }
}

