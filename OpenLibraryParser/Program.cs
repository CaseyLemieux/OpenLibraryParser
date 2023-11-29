// See https://aka.ms/new-console-template for more information

//var lineCount = File.ReadAllLines(@"D:\BookManager Books\Individual Collections\authors.txt").Count();
//Console.WriteLine("Number of Lines in Authors File:" + lineCount);


using Newtonsoft.Json;

var path = @"D:\\BookManager Books\\Individual Collections\\authors.txt\";

using StreamReader sr = File.OpenText(path);
var firstLine = sr.ReadLine();
if (firstLine != null)
{
    var stringArray = firstLine.Split("\t");
    //var json = JsonNode.Parse(stringArray[4]);
    Console.WriteLine(stringArray[4]);
    var list = JsonConvert.DeserializeObject<Author>(stringArray[4]);
    Console.WriteLine(list.Name);
    Console.WriteLine(list.PersonalName);
    Console.WriteLine(list.LastModified.Type);
    Console.WriteLine(list.LastModified.Value);
    Console.WriteLine(list.Key);
    Console.WriteLine(list.Revision);
}


public class Author
{
    public string Name { get; set; }
    [JsonProperty("personal_name")]
    public string PersonalName { get; set; }
    [JsonProperty("last_modified")]
    public LastModified LastModified { get; set; }
    public string Key { get; set; }
    public string Revision { get; set; }
}

public class LastModified
{
    public string Type { get; set; }
    public DateTime Value { get; set; }
}