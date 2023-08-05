namespace KUSYS.Application.Common.Dtos
{
    public class DataResponseDto<T> : ResponseDto
    {
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
    }
}
