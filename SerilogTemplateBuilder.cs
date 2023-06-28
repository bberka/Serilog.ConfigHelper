using Serilog.ConfigHelper.Internal;

namespace Serilog.ConfigHelper;

public class SerilogTemplateBuilder
{
    private const string LevelTemplate = "{Level:u3}";
    private const string TimeStampTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}";
    private const string MessageTemplate = "{Message:lj}";

    private const string ExceptionTemplate = "{NewLine}{Exception}";

    // private readonly string _template;
    private readonly List<TemplateElement> _list;

    public SerilogTemplateBuilder() {
        _list = new List<TemplateElement>();
        // _template = string.Empty;
    }

    private int LastElementOrderNumber() {
        return _list.Count == 0 ? 0 : _list.Max(x => x.Order);
    }

    public SerilogTemplateBuilder AddTimeStamp(bool useSquareBracket = false) {
        var order = LastElementOrderNumber() + 1;
        if (useSquareBracket) {
            _list.Add(new TemplateElement(order, TemplateElementType.Timestamp, $"[{TimeStampTemplate}]"));
            return this;
        }

        _list.Add(new TemplateElement(order, TemplateElementType.Timestamp, TimeStampTemplate));
        return this;
    }

    public SerilogTemplateBuilder AddLevel(bool useSquareBracket = true) {
        var order = LastElementOrderNumber() + 1;
        if (useSquareBracket) {
            _list.Add(new TemplateElement(order, TemplateElementType.Level, $"[{LevelTemplate}]"));
            return this;
        }

        _list.Add(new TemplateElement(order, TemplateElementType.Level, LevelTemplate));
        return this;
    }

    public SerilogTemplateBuilder AddMessage(bool useSquareBracket = false) {
        var order = LastElementOrderNumber() + 1;
        if (useSquareBracket) {
            _list.Add(new TemplateElement(order, TemplateElementType.Message, $"[{MessageTemplate}]"));
            return this;
        }

        _list.Add(new TemplateElement(order, TemplateElementType.Message, MessageTemplate));
        return this;
    }

    public SerilogTemplateBuilder AddException() {
        var order = LastElementOrderNumber() + 1;
        _list.Add(new TemplateElement(order, TemplateElementType.Exception, ExceptionTemplate));
        return this;
    }

    public SerilogTemplateBuilder AddProperty(string propertyName, bool useSquareBracket = false) {
        var order = LastElementOrderNumber() + 1;
        if (useSquareBracket)
            propertyName = $"[{{{propertyName}}}]";
        else
            propertyName = $"{{{propertyName}}}";
        _list.Add(new TemplateElement(order, TemplateElementType.Property, propertyName));
        return this;
    }

    public SerilogTemplateBuilder AddNewLine() {
        var order = LastElementOrderNumber() + 1;
        _list.Add(new TemplateElement(order, TemplateElementType.NewLine, Environment.NewLine));
        return this;
    }
    public string Build() {
        var template = string.Join(" ", _list.OrderBy(x => x.Order).Select(x => x.Template));
        return template;
    }
}