/**
http://bitoftech.net/2015/03/11/asp-net-identity-2-1-roles-based-authorization-authentication-asp-net-web-api/
    criar regras no sistema, aluno, professor e coordenador
    utiliza essas regras para exibir apenas as pesquisas que
    o usuario podera responder
* */
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    // public int RoleI { get; set; }
}

public class Survey
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Datetime Start { get; set; }
    public Datetime End { get; set; }

    // public List<Question> Questions { get; set; }
}

public class Subject
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class SubjectUser
{
    //usar chave composta
    // public int Id { get; set; }
    public int UserId { get; set; }
    public int SubjectId { get; set; }
    // public int SurveyId { get; set; }
}

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    //adicionar regra pra saber quem pode responder a pergunta
    public int TargetId { get; set; }
    public bool Mandatory { get; set; }
    public byte Type { get; set; }
}

public class SurveyQuestion
{
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public int QuestionId { get; set; } 
}

public class Answer
{
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public int QuestionId { get; set; }
    public int SubjectId { get; set; }
    public int RoleId { get; set; }
    public string Value { get; set; }
}