namespace Bike.Common.Models
{
    public enum ResponseCode 
    {
        Success = 200,
        InternalError = 500,
        GeneralError = 700,
        NotFound = 404,
        BadRequest = 400,
        NoContent = 204,
        Created = 201,
        Unauthorized = 401,
        Forbid = 403
    }
}
