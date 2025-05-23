# 📒 ToDoApp - Приложение для управления задачами

## Проблема
При ручном управлении списком задач часто возникают ситуации:
- Случайное удаление важных задач
- Необходимость отмены ошибочных действий
- Отсутствие истории изменений
- Невозможность восстановления ранее удаленных задач

## Задача
Реализовать приложение для управления задачами с:
- Добавлением и удалением задач
- Механизмом отмены действий (Undo)
- Механизмом повтора действий (Redo)
- Поддержкой горячих клавиш (Ctrl+Z/Ctrl+Y)

## Основные функции
- Добавление новых задач
- Удаление выбранных задач
- Отмена последнего действия (Undo)
- Повтор отмененного действия (Redo)
- Визуальное отображение списка задач

## Зачем нужен Command?
### Инкапсуляция операций
- Каждое действие представляется как объект
- Параметры операции сохраняются внутри команды

### Поддержка отмены операций
- Возможность отката изменений
- Хранение истории операций

### Гибкость архитектуры
- Легкое добавление новых типов операций
- Разделение кода UI и бизнес-логики

## Архитектура

### Классы проекта
- `Form1` - Главная форма приложения
- `ITaskCommand` - Интерфейс команды
- `AddTaskCommand` - Команда добавления задачи
- `DeleteTaskCommand` - Команда удаления задачи
- `Program` - Точка входа в приложение

### Ключевые компоненты
```csharp
public interface ITaskCommand
{
    void Execute();
    void Undo();
}

public class AddTaskCommand : ITaskCommand
{
    // Реализация добавления задачи
}

public class DeleteTaskCommand : ITaskCommand
{
    // Реализация удаления задачи
}
