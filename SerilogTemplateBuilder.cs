using Serilog.ConfigHelper.Internal;

namespace Serilog.ConfigHelper;

public class SerilogTemplateBuilder
{
    private readonly string _template;
    private readonly List<TemplateElement> _list;

    private const string LevelTemplate = "{Level:u3}";
    private const string TimeStampTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}";
    private const string MessageTemplate = "{Message:lj}";
    private const string ExceptionTemplate = "{Exception}";

    public SerilogTemplateBuilder() {
        _list = new();
        _template = string.Empty;
    }

    public SerilogTemplateBuilder AddTimeStamp(int order = 0, bool useSquareBracket = false) {
        if (useSquareBracket) {
            _list.Add(new TemplateElement(order, TemplateElementType.Timestamp, $"[{TimeStampTemplate}]"));
            return this;
        }
        _list.Add(new TemplateElement(order, TemplateElementType.Timestamp, TimeStampTemplate));
        return this;
    }

    public SerilogTemplateBuilder AddLevel(int order = 1, bool useSquareBracket = true) {
        if (useSquareBracket) {
            _list.Add(new TemplateElement(order, TemplateElementType.Level, $"[{LevelTemplate}]"));
            return this;
        }
        _list.Add(new TemplateElement(order, TemplateElementType.Level, LevelTemplate));
        return this;
    }

    public SerilogTemplateBuilder AddMessage(int order = 2, bool useSquareBracket = false) {
        if (useSquareBracket) {
            _list.Add(new TemplateElement(order, TemplateElementType.Message, $"[{MessageTemplate}]"));
            return this;
        }
        _list.Add(new TemplateElement(order, TemplateElementType.Message, MessageTemplate));
        return this;
    }

    public SerilogTemplateBuilder AddException(int order = 99) {
        _list.Add(new TemplateElement(order, TemplateElementType.Exception, ExceptionTemplate));
        return this;
    }

    public SerilogTemplateBuilder AddProperty(int order, string propertyName, bool useSquareBracket = false) {
        if (useSquareBracket) {
            propertyName = $"[{propertyName}]";
        }
        _list.Add(new TemplateElement(order, TemplateElementType.Property, propertyName));
        return this;
    }

    public string Build() {
        var template = string.Join(" ", _list.OrderBy(x => x.Order).Select(x => x.Template));
        return template;
    }
}