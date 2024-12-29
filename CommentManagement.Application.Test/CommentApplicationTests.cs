using CommentManagement.Application.Comments;
using CommentManagement.Application.Comments.Contracts;
using CommentManagement.Application.Users.Contracts;
using CommentManagement.Entity.Test.Users;
using FluentAssertions;
using Moq;

namespace CommentManagement.Application.Test
{
    public class CommentApplicationTests
    {
        private readonly Mock<ICommentRepository> _commentRepositoryMock;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly ICommentApplication _sut;


        public CommentApplicationTests()
        {
            _commentRepositoryMock = new Mock<ICommentRepository>();
            _userRepository = new Mock<IUserRepository>();

            _sut = new CommentApplication(_userRepository.Object,
                _commentRepositoryMock.Object);
        }

        [Fact]
        public void ApproveAsync_ApproveCommentAsync()
        {
            // arrange
            var someComment = new CommentBuilder()
                .Build();

            _commentRepositoryMock
                .Setup(r => r.FindByIdAsync(someComment.Id))
                .ReturnsAsync(someComment);

            // act
            Action act = () => _sut.ApproveAsync(someComment.Id)
            .GetAwaiter()
            .GetResult();

            // assert
            act.Should()
                .NotThrow();
        }
    }
}