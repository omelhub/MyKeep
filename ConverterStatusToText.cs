namespace MyKeep;

internal class ConverterStatusToText : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((TaskStatus)value)
        {
            case TaskStatus.Created: return "Задача создана";
            case TaskStatus.Running: return "Задача в работе";
            case TaskStatus.Paused: return "Задача приостановлена";
            case TaskStatus.Completed: return "Задача завершена";
        }

        return "fail1";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((string)value)
        {
            case "Задача создана": return TaskStatus.Created;
            case "Задача в работе": return TaskStatus.Running;
            case "Задача приостановлена": return TaskStatus.Paused;
            case "Задача завершена": return TaskStatus.Completed;
        }

        return "fail2";
    }
}
