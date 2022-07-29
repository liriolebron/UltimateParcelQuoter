using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using UltimateParcelQuoter.Controllers;
using UltimateParcelQuoter.DTOs.DHLService;
using UltimateParcelQuoter.DTOs.FedExService;
using UltimateParcelQuoter.DTOs.UPSService;
using UltimateParcelQuoter.Interfaces;
using UltimateParcelQuoter.Models;
using UltimateParcelQuoter.Services;

namespace UltimateParcerQuoterTests;

public class ParcelQuoterTests
{
    private Mock<IPostalService<DHLPackageQuoteDTO, DHLPackageQuoteResponseDTO>> dhlMock;
    private Mock<IPostalService<FedExPackageQuoteDTO, FedExPackageQuoteResponseDTO>> fedExMock;
    private Mock<IPostalService<UPSPackageQuoteDTO, UPSPackageQuoteResponseDTO>> upsMock;
    private IParcelQuoter parcelQuoter;

    [SetUp]
    public void Setup()
    {
        dhlMock = new Mock<IPostalService<DHLPackageQuoteDTO, DHLPackageQuoteResponseDTO>>();
        dhlMock.Setup(dhl => dhl.Quote(It.IsAny<DHLPackageQuoteDTO>()))
            .Returns(Task.FromResult(new DHLPackageQuoteResponseDTO()
            {
                Total = 1
            }));

        fedExMock = new Mock<IPostalService<FedExPackageQuoteDTO, FedExPackageQuoteResponseDTO>>();
        fedExMock.Setup(dhl => dhl.Quote(It.IsAny<FedExPackageQuoteDTO>()))
            .Returns(Task.FromResult(new FedExPackageQuoteResponseDTO()
            {
                Amount = 2
            }));

        upsMock = new Mock<IPostalService<UPSPackageQuoteDTO, UPSPackageQuoteResponseDTO>>();
        upsMock.Setup(dhl => dhl.Quote(It.IsAny<UPSPackageQuoteDTO>()))
            .Returns(Task.FromResult(new UPSPackageQuoteResponseDTO()
            {
                Quote = 3
            }));

        parcelQuoter = new ParcelQuoter(dhlMock.Object, fedExMock.Object, upsMock.Object);
    }

    [Test]
    public async Task Test_Should_Return_Lowest_Amount()
    {
        var packageQuote = new PackageQuote()
        {
            SourceAddress = "Source",
            DestinationAddress = "Destination",
            Packages = new() 
            {
                new() 
                {
                    Height = 1,
                    Length = 1,
                    Weight = 1,
                    Width = 1
                }
            }
        };

        var result = await parcelQuoter.Quote(packageQuote);        

        Assert.That(result, Is.EqualTo("Best price offered by DHL, Quoted amount: $1.00"));
    }

    [Test]
    public async Task Test_Controller_Should_Return_Bad_Request_If_No_Packages()
    {
        var controller = new QuotePackageController(parcelQuoter);
        var response = await controller.Quote(new());

        Assert.That(response, Is.InstanceOf<BadRequestResult>());
    }
}
