﻿using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.ModelLayer.Auction;
using Auction_House_MVC.ModelLayer.Bid;
using Auction_House_MVC.ServiceLayer.AuctionServiceReference;
using Auction_House_MVC.ServiceLayer.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.ServiceLayer.Utility
{
    public class ConvertDataModel
    {
        public AuctionData ConvertFromCreateAuctionToAuctionData(CreateAuction createAuction)
        {
            AuctionData aD = new AuctionData
            {
                UserName = createAuction.UserName,
                StartPrice = createAuction.StartPrice,
                BuyOutPrice = createAuction.BuyOutPrice,
                BidInterval = createAuction.BidInterval,
                Description = createAuction.Description,
                EndDate = createAuction.EndDate,
                Category = createAuction.Category,
            };
            return aD;
        }

        /// <summary>
        /// Converts UserData from service to modellayer userlogin.
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        public UserLogin ConvertFromUserDataToLogin(UserData userData)
        {
            UserLogin userLogin = new UserLogin
            {
                Id = userData.Id,
                Salt = userData.Salt,
                Hash = userData.PasswordHash
            };
            return userLogin;
        }

        /// <summary>
        /// Converts UserData from servicelayer to modellayer user.
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        public User ConvertFromUserDataToUser(UserData userData)
        {
            User user = new User
            {
                Id = userData.Id,
                UserName = userData.UserName,
                Email = userData.Email,
                Phone = userData.Phone,
                ZipCode = userData.ZipCode,
                Region = userData.Region
            };
            return user;
        }

        public ImageData[] ConvertFromImagesToImageData(List<Image> images)
        {
            ImageData[] imageData = new ImageData[images.Count];
            int i = 0;
            foreach(Image image in images)
            {
                ImageData imageD = new ImageData
                {
                    AuctionId = image.AuctionId,
                    UserId = image.UserId,
                    Description = image.Description,
                    FileName = image.FileName,
                    FileStream = image.FileStream
                };
                imageData[i] = imageD;
                i++;
            }
            return imageData;
        }

        public ImageData1 ConvertFromImageToImageData(Image image)
        {

                ImageData1 imageD = new ImageData1
                {
                    AuctionId = image.AuctionId,
                    UserId = image.UserId,
                    Description = image.Description,
                    FileName = image.FileName,
                    FileStream = image.FileStream
                };

            return imageD;
        }

        public List<Auction> ConvertFromAuctionDataToAuctions(AuctionData[] auctionData)
        {
            List<Auction> auctions = new List<Auction>();

            foreach (AuctionData aD in auctionData)
            {
                Auction auction = ConvertFromAuctionDataToAuction(aD);
                auctions.Add(auction);
            }
            return auctions;
        }

        public Auction ConvertFromAuctionDataToAuction(AuctionData aD)
        {
            if (aD != null)
            {
                Auction auction = new Auction(
                    aD.Id,
                    aD.StartPrice,
                    aD.BuyOutPrice,
                    aD.BidInterval,
                    aD.Description,
                    aD.StartDate,
                    aD.EndDate,
                    aD.Category);
                auction.UserName = aD.UserName;
                auction.ZipCode = aD.ZipCode;
                auction.Region = aD.Region;
                return auction;
            } else
            {
                return null;
            }

        }

        //Convert from system.array to generic list.
        public List<string> ConvertFromBasicArrayToGenericArray(string[] array)
        {
            return new List<string>(array);
        }

        public Image ConvertRemoteFileInfoToImage(RemoteFileInfo rFI)
        {
            Image image = new Image
            { 
                Description = rFI.FileName,
                FileStream = rFI.FileByteStream
            };
            return image;
        }

        public Image ConvertFromImageInfoDataToImage(ImageInfoData imageInfoData)
        {
            Image image = new Image
            {
                AuctionId = imageInfoData.AuctionId,
                FileName = imageInfoData.FileName,
                Description = imageInfoData.Description,
            };
            return image;
        }

        public List<Image> ConvertFromImageInfoDataToImages(ImageInfoData[] imageData)
        {
            List<Image> images = new List<Image>();
            foreach (ImageInfoData sImageInfoData in imageData)
            {
                images.Add(ConvertFromImageInfoDataToImage(sImageInfoData));
            }
            return images;
        }

        public Bid ConvertFromBidDataToBid(BidData bidData)
        {
            Bid bid = new Bid
            {
                Bid_Id = bidData.Bid_Id,
                Auction_Id = bidData.Auction_Id,
                User_Id = bidData.User_Id,
                Amount = bidData.Amount,
                Date = bidData.Date,
                UserName = bidData.UserName
            };
            return bid;
        }

        public List<Bid> ConvertFromBidDataToBids(BidData[] bidData)
        {
            List<Bid> bids = new List<Bid>();
            foreach (BidData sBidData in bidData)
            {
                bids.Add(ConvertFromBidDataToBid(sBidData));
            }
            return bids;
        }

        public BidData ConvertFromBidToBidData(Bid bid)
        {
            BidData bidData = new BidData
            {
                Auction_Id = bid.Auction_Id,
                User_Id = bid.User_Id,
                Amount = bid.Amount,
                Date = bid.Date,
                UserName = bid.UserName
            };
            return bidData;
        }
    }
}