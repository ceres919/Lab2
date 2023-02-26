using Avalonia.Media;
using StudentsProgress.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProgress.Models
{
    public class Student: OnNotifyPropertyChanged 
    {
        private float sr_scores = 0;
        private ushort[] scores = {0, 0, 0, 0};
        private string name = "";
        private void Update()
        {
            ushort S = 0;
            foreach (ushort i in scores) S += i;
            Average_Score = (float) S / 4;
            var main = MainWindowViewModel.inst;
            if (main != null) main.CheckAverage();
        }
        public string Name 
        { 
            get => name; 
            set => name = value; 
        }

        public ushort VisualProg
        {
            get => scores[0];
            set
            {
                SetProperty(ref scores[0], value);
                Update();
            }
        }


        public ushort Architecture
        {
            get => scores[1];
            set 
            {
                SetProperty(ref scores[1], value);
                Update();
            }
        }

        public ushort Networks
        {
            get => scores[2];
            set 
            {
                SetProperty(ref scores[2], value);
                Update();
            }
        }

        public ushort CalcMath
        {
            get => scores[3];
            set
            {
                SetProperty(ref scores[3], value);
                Update();
            }
        }

        public float Average_Score
        {
            get
            {
                sr_scores = 0;
                foreach (ushort num in scores)
                {
                    sr_scores += num;
                }
                return sr_scores /= 4;
            }
            set => SetProperty(ref sr_scores, value);
        }
    }
}
