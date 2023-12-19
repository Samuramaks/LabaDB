namespace WinFormsApp
{
    partial class Monitoring
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
            imageMachine = new PictureBox();
            nameMachineBox = new ComboBox();
            btnPlay = new Button();
            btnStop = new Button();
            typeMachine = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dateBox = new TextBox();
            WpfPlot1 = new ScottPlot.FormsPlot();
            textBoxCNC = new TextBox();
            textBoxReadyCNC = new TextBox();
            textBoxMainMotion = new TextBox();
            textBoxAverageMainMotion = new TextBox();
            textBoxSpindle = new TextBox();
            textBoxReadySpindle = new TextBox();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            logsGrid = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)imageMachine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logsGrid).BeginInit();
            SuspendLayout();
            // 
            // imageMachine
            // 
            imageMachine.Location = new Point(29, 48);
            imageMachine.Name = "imageMachine";
            imageMachine.Size = new Size(134, 91);
            imageMachine.TabIndex = 0;
            imageMachine.TabStop = false;
            // 
            // nameMachineBox
            // 
            nameMachineBox.FormattingEnabled = true;
            nameMachineBox.Location = new Point(29, 234);
            nameMachineBox.Name = "nameMachineBox";
            nameMachineBox.Size = new Size(134, 23);
            nameMachineBox.TabIndex = 1;
            nameMachineBox.SelectedIndexChanged += nameMachineBox_SelectedIndexChanged;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(29, 166);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(134, 23);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Запуск";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(29, 195);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(134, 23);
            btnStop.TabIndex = 3;
            btnStop.Text = "Остановить";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // typeMachine
            // 
            typeMachine.Location = new Point(29, 273);
            typeMachine.Name = "typeMachine";
            typeMachine.Size = new Size(134, 23);
            typeMachine.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(29, 333);
            button1.Name = "button1";
            button1.Size = new Size(134, 23);
            button1.TabIndex = 5;
            button1.Text = "Главная";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(29, 362);
            button2.Name = "button2";
            button2.Size = new Size(134, 23);
            button2.TabIndex = 6;
            button2.Text = "Мониторинг";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(29, 391);
            button3.Name = "button3";
            button3.Size = new Size(134, 23);
            button3.TabIndex = 7;
            button3.Text = "Анализ";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(29, 420);
            button4.Name = "button4";
            button4.Size = new Size(134, 23);
            button4.TabIndex = 8;
            button4.Text = "Отчет";
            button4.UseVisualStyleBackColor = true;
            // 
            // dateBox
            // 
            dateBox.Location = new Point(270, 12);
            dateBox.Name = "dateBox";
            dateBox.Size = new Size(134, 23);
            dateBox.TabIndex = 9;
            // 
            // WpfPlot1
            // 
            WpfPlot1.Location = new Point(183, 48);
            WpfPlot1.Margin = new Padding(4, 3, 4, 3);
            WpfPlot1.Name = "WpfPlot1";
            WpfPlot1.Size = new Size(350, 248);
            WpfPlot1.TabIndex = 10;
            // 
            // textBoxCNC
            // 
            textBoxCNC.Location = new Point(229, 333);
            textBoxCNC.Name = "textBoxCNC";
            textBoxCNC.Size = new Size(134, 23);
            textBoxCNC.TabIndex = 11;
            // 
            // textBoxReadyCNC
            // 
            textBoxReadyCNC.Location = new Point(399, 333);
            textBoxReadyCNC.Name = "textBoxReadyCNC";
            textBoxReadyCNC.Size = new Size(134, 23);
            textBoxReadyCNC.TabIndex = 12;
            // 
            // textBoxMainMotion
            // 
            textBoxMainMotion.Location = new Point(229, 377);
            textBoxMainMotion.Name = "textBoxMainMotion";
            textBoxMainMotion.Size = new Size(134, 23);
            textBoxMainMotion.TabIndex = 13;
            // 
            // textBoxAverageMainMotion
            // 
            textBoxAverageMainMotion.Location = new Point(399, 377);
            textBoxAverageMainMotion.Name = "textBoxAverageMainMotion";
            textBoxAverageMainMotion.Size = new Size(134, 23);
            textBoxAverageMainMotion.TabIndex = 14;
            // 
            // textBoxSpindle
            // 
            textBoxSpindle.Location = new Point(229, 415);
            textBoxSpindle.Name = "textBoxSpindle";
            textBoxSpindle.Size = new Size(134, 23);
            textBoxSpindle.TabIndex = 15;
            // 
            // textBoxReadySpindle
            // 
            textBoxReadySpindle.Location = new Point(399, 415);
            textBoxReadySpindle.Name = "textBoxReadySpindle";
            textBoxReadySpindle.Size = new Size(134, 23);
            textBoxReadySpindle.TabIndex = 16;
            // 
            // button5
            // 
            button5.Location = new Point(534, 12);
            button5.Name = "button5";
            button5.Size = new Size(186, 23);
            button5.TabIndex = 17;
            button5.Text = "СЧПУ";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(746, 12);
            button6.Name = "button6";
            button6.Size = new Size(134, 23);
            button6.TabIndex = 18;
            button6.Text = "Шпиндель";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(534, 48);
            button7.Name = "button7";
            button7.Size = new Size(186, 23);
            button7.TabIndex = 19;
            button7.Text = "Привод главного движения";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(534, 87);
            button8.Name = "button8";
            button8.Size = new Size(186, 23);
            button8.TabIndex = 20;
            button8.Text = "Отправить логи в бд";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(746, 48);
            button9.Name = "button9";
            button9.Size = new Size(134, 23);
            button9.TabIndex = 21;
            button9.Text = "Показать все логи";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // logsGrid
            // 
            logsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            logsGrid.Location = new Point(540, 128);
            logsGrid.Name = "logsGrid";
            logsGrid.Size = new Size(348, 310);
            logsGrid.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 15);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 23;
            label1.Text = "Control CNC";
            // 
            // Monitoring
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 450);
            Controls.Add(label1);
            Controls.Add(logsGrid);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(textBoxReadySpindle);
            Controls.Add(textBoxSpindle);
            Controls.Add(textBoxAverageMainMotion);
            Controls.Add(textBoxMainMotion);
            Controls.Add(textBoxReadyCNC);
            Controls.Add(textBoxCNC);
            Controls.Add(WpfPlot1);
            Controls.Add(dateBox);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(typeMachine);
            Controls.Add(btnStop);
            Controls.Add(btnPlay);
            Controls.Add(nameMachineBox);
            Controls.Add(imageMachine);
            Name = "Monitoring";
            Text = "Monitoring";
            ((System.ComponentModel.ISupportInitialize)imageMachine).EndInit();
            ((System.ComponentModel.ISupportInitialize)logsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imageMachine;
        private ComboBox nameMachineBox;
        private Button btnPlay;
        private Button btnStop;
        private TextBox typeMachine;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox dateBox;
        private ScottPlot.FormsPlot WpfPlot1;
        private TextBox textBoxCNC;
        private TextBox textBoxReadyCNC;
        private TextBox textBoxMainMotion;
        private TextBox textBoxAverageMainMotion;
        private TextBox textBoxSpindle;
        private TextBox textBoxReadySpindle;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private DataGridView logsGrid;
        private Label label1;
    }
}