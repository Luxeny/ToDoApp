using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using ToDoApp.Commands;

namespace ToDoApp
{
    public partial class Form1 : Form
    {
        private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        public Form1()
        {
            InitializeComponent();
            SetupEventHandlers();
            SetupHotkeys();
        }

        private void SetupEventHandlers()
        {
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUndo.Click += BtnUndo_Click;
            btnRedo.Click += BtnRedo_Click;
        }

        private void SetupHotkeys()
        {
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.Z) Undo();
                if (e.Control && e.KeyCode == Keys.Y) Redo();
            };
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTask.Text))
            {
                var cmd = new AddTaskCommand(lstTasks, txtTask.Text);
                cmd.Execute();
                _undoStack.Push(cmd);
                _redoStack.Clear();
                txtTask.Clear();
                txtTask.Focus();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                var cmd = new DeleteTaskCommand(lstTasks, lstTasks.SelectedIndex);
                cmd.Execute();
                _undoStack.Push(cmd);
                _redoStack.Clear();
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e) => Undo();
        private void BtnRedo_Click(object sender, EventArgs e) => Redo();

        private void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var cmd = _undoStack.Pop();
                cmd.Undo();
                _redoStack.Push(cmd);
            }
        }

        private void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var cmd = _redoStack.Pop();
                cmd.Execute();
                _undoStack.Push(cmd);
            }
        }
    }
}