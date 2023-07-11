namespace Application.Responses;

public class DeleteUserRequest : BaseRequest
{
    public DeleteUserRequest(int id) => Id = id;

    public int Id { get; }
}