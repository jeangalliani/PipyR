using System;
using System.Collections.Generic;

namespace PipyR
{
    public abstract class ProgressCommand<TResponse> : Command<TResponse>
    {
        public abstract long ProgressSize { get; }
        private long _sucessProgress = 0;
        public long TotalProgress => ProgressSuccess + ProgressFail + ProgressWarning;
        public long ProgressSuccess
        {
            get => _sucessProgress;
            set
            {
                _sucessProgress = value;
                UpdateProgressSumary(ProgressSumaryType.Success);
            }
        }

        private long _failProgress = 0;
        public long ProgressFail
        {
            get => _failProgress;
            set
            {
                _failProgress = value;
                UpdateProgressSumary(ProgressSumaryType.Fail);
            }
        }

        private long _warningProgress = 0;
        public long ProgressWarning
        {
            get => _warningProgress;
            set
            {
                _warningProgress = value;
                UpdateProgressSumary(ProgressSumaryType.Warning);
            }
        }
        private decimal AbsoluteProgressPercentage
        {
            get => ((decimal)TotalProgress / ProgressSize) * 100;
        }

        public decimal ProgressPercentage
        {
            get => Math.Round(AbsoluteProgressPercentage, 2);
        }

        private bool _firstCurrentProgressSumary = true;
        private void UpdateProgressSumary(ProgressSumaryType type)
        {
            if (CurrentProgressSumary is not null && CurrentProgressSumary.Type != type)
            {
                TotalProgressSumaryPercentage += CurrentProgressSumary.Percentage;
                if (!_firstCurrentProgressSumary)
                    ProgressHistory.Add(CurrentProgressSumary);
                else
                    _firstCurrentProgressSumary = false;

                CurrentProgressSumary = new(type, 0);
            }

            if (CurrentProgressSumary is null)
            {
                CurrentProgressSumary = new(type, AbsoluteProgressPercentage);
                ProgressHistory.Add(CurrentProgressSumary);
            }
            else
                CurrentProgressSumary.Percentage = AbsoluteProgressPercentage - TotalProgressSumaryPercentage;

            if (IsCompleted)
            {
                TotalProgressSumaryPercentage += CurrentProgressSumary.Percentage;

                if (CurrentProgressSumary.Percentage != 100)
                    ProgressHistory.Add(CurrentProgressSumary);
            }
        }
        public bool IsCompleted { get => TotalProgress == ProgressSize; }
        private ICollection<ProgressSumary> _progressHistory;
        public ICollection<ProgressSumary> ProgressHistory => _progressHistory ??= new List<ProgressSumary>();
        private ProgressSumary CurrentProgressSumary { get; set; }
        private decimal TotalProgressSumaryPercentage { get; set; }
    }

    public enum ProgressSumaryType : byte
    {
        Success = 1,
        Warning = 2,
        Fail = 3
    }

    public class ProgressSumary
    {
        public ProgressSumary(ProgressSumaryType type, decimal percentage)
        {
            Type = type;
            Percentage = percentage;
        }

        public ProgressSumaryType Type { get; set; }
        public decimal Percentage { get; set; }
    }
}