using Avalonia.Media;
using StudentsProgress.Models;
using ReactiveUI;
using System;
using System.Reactive;
using System.Linq;
using StudentsProgress.ViewModels;

namespace StudentsProgress.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel? inst;
        private Student[] students = new Student[]
            {
                new Student{Name="Иванов Александр Степанович", VisualProg=1, Architecture=2, Networks=0, CalcMath=2},
                new Student{Name="Степанова Надеждай Андреевна", VisualProg=2, Architecture=2, Networks=1, CalcMath=1},
                new Student{Name="Малахов Сергей Петрович", VisualProg=2, Architecture=1, Networks=1, CalcMath=1},
            };

        private SolidColorBrush checkColor(float num)
        {
            if (num < 1) return new SolidColorBrush(Colors.Red);
            if (num < 1.5) return new SolidColorBrush(Colors.Yellow);
            else return new SolidColorBrush(Colors.Green);
        }

        public void CheckAverage()
        {
            ushort Score1 = 0, Score2 = 0, Score3 = 0, Score4 = 0;
            float Score5 = 0;
            for (int i = 0; i < 5; i++)
            {
                sc_scores[i] = 0;
            }
            for (int i = 0; i < students.Length; i++)
            {
                Score1 += students[i].VisualProg;
                Score2 += students[i].Architecture;
                Score3 += students[i].Networks;
                Score4 += students[i].CalcMath;
                Score5 += students[i].Average_Score;
            }
            ScoreVisualSr = (float)Score1/students.Length;
            ColorVisualSr = checkColor(ScoreVisualSr);
            ScoreArchitectureSr = (float)Score2 / students.Length;
            ColorArchitectureSr = checkColor(ScoreArchitectureSr);
            ScoreNetworksSr = (float)Score3 / students.Length;
            ColorNetworksSr = checkColor(ScoreNetworksSr);
            ScoreCalculate_MathSr = (float)Score4 / students.Length;
            ColorCalculate_MathSr = checkColor(ScoreCalculate_MathSr);

            ScoreAverageSr = (float)Score5 / students.Length;
            ColorAverageSr = checkColor(ScoreAverageSr);
            
            //int len = students.Length;
            //ushort Score1 = 0, Score2 = 0, Score3 = 0, Score4 = 0;
            //float Score5 = 0;
            //for (int i = 0; i < 5; i++)
            //{
            //    sc_scores[i] = 0;
            //}
            //foreach (Student student in students)
            //{
            //    Score1 += student.VisualProg;
            //    Score2 += student.Architecture;
            //    Score3 += student.Networks;
            //    Score4 += student.CalcMath;
            //}
            //ScoreVisualSr = (float) Score1 / len;
            //ColorVisualSr = checkColor(ScoreVisualSr);
            //ScoreArchitectureSr = (float) Score2 / len;
            //ColorArchitectureSr = checkColor(ScoreArchitectureSr);
            //ScoreNetworksSr = (float) Score3 / len;
            //ColorNetworksSr = checkColor(ScoreNetworksSr);
            //ScoreCalculate_MathSr = (float) Score4 / len;
            //ColorCalculate_MathSr = checkColor(ScoreCalculate_MathSr);

            //ScoreAverageSr = (float) Score5 / len;
            //ColorAverageSr = checkColor(ScoreAverageSr);
        }
        public MainWindowViewModel()
        {
            inst = this;
            //GlobalUpdate();

            AddStudent = ReactiveCommand.Create(() =>
            {
                if (newName != "")
                {
                    Student[] temp = students;
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = new Student { Name = newName, VisualProg = scores[0], Architecture = scores[1], Networks = scores[2], CalcMath = scores[3] };
                    Students = temp;
                    NewName = "";
                    ScoreVisual = 0;
                    ScoreArchitecture = 0;
                    ScoreNetworks = 0;
                    ScoreCalculate_Math = 0;
                    CheckAverage();
                }
            });
            DeleteStudent = ReactiveCommand.Create(() =>
            {
                if (index < students.Length)
                {
                    Student[] temp = students;
                    for (int i = index; i < temp.Length - 1; i++)
                    {
                        temp[i] = temp[i + 1];
                    }
                    Array.Resize(ref temp, temp.Length - 1);
                    Students = temp;
                    Index = 5000;
                    CheckAverage();
                }
            });
            Save = ReactiveCommand.Create(() =>
            {
                Serializer<Student[]>.Save("data.dat", students);
            });
            Load = ReactiveCommand.Create(() =>
            {
                Students = Serializer<Student[]>.Load("data.dat");
                CheckAverage();
            });
            CheckAverage();

        }

        public Student[] Students
        {
            get => students;
            set => this.RaiseAndSetIfChanged(ref students, value);
        }

        public ReactiveCommand<Unit, Unit> AddStudent { get; }
        public ReactiveCommand<Unit, Unit> DeleteStudent { get; }
        public ReactiveCommand<Unit, Unit> Save { get; }
        public ReactiveCommand<Unit, Unit> Load { get; }

        private ushort[] scores = { 0, 0, 0, 0 };
        private string newName = "";
        private ushort index = 5000;
        private float[] sc_scores = { 0, 0, 0, 0, 0 };
        private SolidColorBrush[] colorBrush = new SolidColorBrush[5];
        public ushort Index { get => index; set => this.RaiseAndSetIfChanged(ref index, value); }
        public string NewName { get => newName; set => this.RaiseAndSetIfChanged(ref newName, value); }
        public ushort ScoreVisual { get => scores[0]; set => this.RaiseAndSetIfChanged(ref scores[0], value); }
        public ushort ScoreArchitecture { get => scores[1]; set => this.RaiseAndSetIfChanged(ref scores[1], value); }
        public ushort ScoreNetworks { get => scores[2]; set => this.RaiseAndSetIfChanged(ref scores[2], value); }
        public ushort ScoreCalculate_Math { get => scores[3]; set => this.RaiseAndSetIfChanged(ref scores[3], value); }

        public float ScoreVisualSr { get => sc_scores[0]; set => this.RaiseAndSetIfChanged(ref sc_scores[0], value); }
        public float ScoreArchitectureSr { get => sc_scores[1]; set => this.RaiseAndSetIfChanged(ref sc_scores[1], value); }
        public float ScoreNetworksSr { get => sc_scores[2]; set => this.RaiseAndSetIfChanged(ref sc_scores[2], value); }
        public float ScoreCalculate_MathSr { get => sc_scores[3]; set => this.RaiseAndSetIfChanged(ref sc_scores[3], value); }

        public float ScoreAverageSr { get => sc_scores[4]; set => this.RaiseAndSetIfChanged(ref sc_scores[4], value); }

        public SolidColorBrush ColorVisualSr { get => colorBrush[0]; set => this.RaiseAndSetIfChanged(ref colorBrush[0], value); }
        public SolidColorBrush ColorArchitectureSr { get => colorBrush[1]; set => this.RaiseAndSetIfChanged(ref colorBrush[1], value); }
        public SolidColorBrush ColorNetworksSr { get => colorBrush[2]; set => this.RaiseAndSetIfChanged(ref colorBrush[2], value); }
        public SolidColorBrush ColorCalculate_MathSr { get => colorBrush[3]; set => this.RaiseAndSetIfChanged(ref colorBrush[3], value); }

        public SolidColorBrush ColorAverageSr { get => colorBrush[4]; set => this.RaiseAndSetIfChanged(ref colorBrush[4], value); }
    }
}
