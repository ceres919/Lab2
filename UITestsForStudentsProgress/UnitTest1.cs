using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;
using Color = Avalonia.Media.Color;

namespace UITestsForStudentsProgress
{
    public class UnitTest1
    {
        

        [Fact]
        public async void add_student_and_save_test()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentButton");
            var buttonSave = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveButton");
            var buttonLoad = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "LoadButton");

            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "TextBoxName");

            buttonSave.Command.Execute(buttonSave.CommandParameter);
            textbox.Text = "Климов Пётр Александрович";
            buttonAdd.Command.Execute(buttonAdd.CommandParameter);


            Assert.True(listBoxItems.Count() == 4);

            buttonLoad.Command.Execute(buttonLoad.CommandParameter);
        }

        [Fact]
        public async void student_save_test()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentButton");
            var buttonSave = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveButton");
            var buttonLoad = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "LoadButton");

            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "TextBoxName");

            buttonSave.Command.Execute(buttonSave.CommandParameter);
            textbox.Text = "Попова Анастасия Евгеньевна";
            buttonAdd.Command.Execute(buttonAdd.CommandParameter);



            buttonLoad.Command.Execute(buttonLoad.CommandParameter);
            string text = listBoxItems.Count().ToString();
            Assert.True(listBoxItems.Count() == 3, text);
        }

        [Fact]
        public async void remove_student_test()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First();

            var listBoxItems = listBox.GetVisualDescendants().OfType<ListBoxItem>();

            var buttonRemove = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "RemoveStudentButton");
            var buttonSave = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveButton");
            var buttonLoad = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "LoadButton");

            buttonSave.Command.Execute(buttonSave.CommandParameter);
            listBox.SelectedIndex = 0;
            buttonRemove.Command.Execute(buttonRemove.CommandParameter);

            Assert.True(listBoxItems.Count() == 2);

            buttonLoad.Command.Execute(buttonLoad.CommandParameter);
        }

        [Fact]
        public async void sr_color_test()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var grid = mainWindow.GetVisualDescendants().OfType<Grid>().First(x => (x.Name != null) && x.Name.Equals("SrGrid"));

            var visualProgrammBorder = grid.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("AverageSrBorder"));
            var textBlockVisualProgramm = grid.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("AverageSrText"));

            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentButton");
            var buttonSave = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveButton");
            var buttonLoad = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "LoadButton");

            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "TextBoxName");

            buttonSave.Command.Execute(buttonSave.CommandParameter);
            textbox.Text = "Тимофеев Матвей Игоревич";
            buttonAdd.Command.Execute(buttonAdd.CommandParameter);

            var text = textBlockVisualProgramm.Text;
            float asd = (float)Convert.ToDouble(text);
            Color c;
            if (asd < 1) c = Colors.Red;
            else if (asd < 1.5) c = Colors.Yellow;
            else c = Colors.Green;
            var color = (visualProgrammBorder.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");

            buttonLoad.Command.Execute(buttonLoad.CommandParameter);
        }
    }
}