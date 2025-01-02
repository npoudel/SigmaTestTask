using BLL.CandidateService;
using DAL;
using Domain.Model;
using Moq;

namespace CandidateInformation.Tests.CandidateTestService
{
    public class CandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _mockRepository;
        private readonly CandidateService _service;

        public CandidateServiceTests()
        {
            _mockRepository = new Mock<ICandidateRepository>();
            _service = new CandidateService(_mockRepository.Object);
        }

        [Fact]
        public void AddOrUpdateCandidate_AddWhenDoesNotExists()
        {
            // Arrange
            var candidate = new Candidate
            {
                Email = "test@test.com",
                FirstName = "testfirstname",
                LastName = "testlast",
                Comment = "Comment123"
            };

            _mockRepository.Setup(r => r.GetCandidateByEmail(candidate.Email)).Returns((Candidate?)null);

            // Act
            _service.AddOrUpdateCandidate(candidate);

            // Assert
            _mockRepository.Verify(r => r.AddCandidate(candidate), Times.Once);
            _mockRepository.Verify(r => r.SaveChanges(), Times.Once);
        }

        [Fact]
        public void AddOrUpdateCandidate_UpdateExistingCandidate()
        {
            // Arrange
            var candidateInfo = new Candidate
            {
                Email = "test@test.com",
                FirstName = "testfirstname",
                LastName = "testlastname",
                Comment = "comment123",
                PhoneNumber = "456788",
                BestCallTime = "",
                LinkedInProfile = "",
                GitHubProfile = ""
            };

            var updatedCandidateInfo = new Candidate
            {
                Email = "test@test.com",
                FirstName = "updatedname",
                LastName = "updatedlast",
                Comment = "updatedcomment",
                BestCallTime = "",
                LinkedInProfile = "",
                GitHubProfile = ""
            };

            _mockRepository.Setup(r => r.GetCandidateByEmail(candidateInfo.Email)).Returns(candidateInfo);

            // Act
            _service.AddOrUpdateCandidate(updatedCandidateInfo);

            // Assert
            Assert.Equal("updatedname", candidateInfo.FirstName);
            Assert.Equal("updatedlast", candidateInfo.LastName);
            Assert.Equal("updatedcomment", candidateInfo.Comment);
            _mockRepository.Verify(r => r.UpdateCandidate(candidateInfo), Times.Once);
            _mockRepository.Verify(r => r.SaveChanges(), Times.Once);
        }
    }
}
