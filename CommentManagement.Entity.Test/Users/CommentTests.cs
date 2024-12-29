using FluentAssertions;

namespace CommentManagement.Entity.Test.Users
{
    public class CommentTests
    {
        [Fact]
        public void Approve_ChangeToTrueIsApprove()
        {
            // arrange
            var someComment = new CommentBuilder()
                .Build();

            // act
            someComment.Approve();

            // assert
            someComment
                .IsApproved
                .Should()
                .BeTrue();

        }
    }
}
