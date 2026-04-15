namespace SharedService.SharedKernel;

public static class GeneralErrors
{
    public static Error Invalid(string? fieldName = null)
    {
        string label = fieldName ?? "значение";
        return Error.Validation("value.is.invalid", $"{label} содержит недопустимое значение", fieldName);
    }

    public static Error NotFound(string entityName = "запись", Guid? id = null)
    {
        string message = id is null
            ? $"{entityName} не найдена"
            : $"{entityName} не найдена по id {id}";

        return Error.NotFound("value.not.found", message);
    }

    public static Error Required(string? fieldName)
    {
        return Error.Validation("value.is.required", $"{fieldName} обязателен", fieldName);
    }

    public static Error LengthOutOfRange(string fieldName, int minLength, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(fieldName))
            throw new ArgumentException("Имя поля обязательно для заполнения", nameof(fieldName));

        if (minLength < 0)
            throw new ArgumentException("minLength должен быть больше или равно нуля", nameof(minLength));

        if (maxLength <= minLength)
            throw new ArgumentException("maxLength должен быть больше minLength");

        return Error.Validation(
            "value.length.out.of.range",
            $"{fieldName} должно быть от {minLength} до {maxLength} символов",
            fieldName);
    }

    public static Error AlreadyExist(string fieldName)
    {
        return Error.Conflict("value.already.exist", $"{fieldName} уже существует", fieldName);
    }

    public static Error Failure()
    {
        return Error.Failure("server.failure", "Серверная ошибка");
    }

    public static Error MismatchRegex(string fieldName)
    {
        return Error.Validation("value.mismatch.regex", $"{fieldName} имеет недопустимый формат", fieldName);
    }

    public static Error Database(string code = "database.failure", string? message = null)
    {
        return Error.Failure(code, message ?? "Произошла ошибка в базе данных.");
    }

    public static Error ArrayContainsDuplicates(string fieldName)
    {
        return Error.Validation("array.contains.duplicates", $"{fieldName} содержит повторяющиеся значения", fieldName);
    }
}