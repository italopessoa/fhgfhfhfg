/**
http://bitoftech.net/2015/03/11/asp-net-identity-2-1-roles-based-authorization-authentication-asp-net-web-api/
    criar regras no sistema, aluno, professor e coordenador
    utiliza essas regras para exibir apenas as pesquisas que
    o usuario podera responder
* *//
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int GroupID { get; set; }
}

public class Survey
{
    public int Id { get; set; }
    public string Description { get; set; }
    public Datetime Start { get; set; }
    public Datetime End { get; set; }

    public List<Question> Questions { get; set; }
}

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class SubjectUser
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SubjectId { get; set; }
    public int SurveyId { get; set; }
}

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
}

public class SurveyQuestion
{
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public int QuestionId { get; set; } 
}