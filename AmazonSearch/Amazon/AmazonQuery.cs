using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Configuration;
using AmazonSearch.PAAPI;
using AmazonSearch;

namespace AmazonSearch
{
    public class AmazonQuery
    {

        public AmazonQuery()
        {

        }

        public ItemLookupResponse LookupByASIN(string[] ASINs, string[] Group)
        {
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.MaxBufferSize = int.MaxValue;

            AWSECommerceServicePortTypeClient amazonClient = new AWSECommerceServicePortTypeClient(
                        binding,
                        new EndpointAddress("https://webservices.amazon.com/onca/soap?Service=AWSECommerceService"));
            // add authentication to the ECS client
            amazonClient.ChannelFactory.Endpoint.Behaviors.Add(new AmazonSigningEndpointBehavior(ConfigurationManager.AppSettings["accessKeyId"], ConfigurationManager.AppSettings["secretKey"]));

            ItemLookupRequest request = new ItemLookupRequest();
            request.ItemId = ASINs;
            request.IdType = ItemLookupRequestIdType.ASIN;
            request.ResponseGroup = Group;

            ItemLookup itemLookup = new ItemLookup();
            itemLookup.Request = new ItemLookupRequest[] { request };
            itemLookup.AWSAccessKeyId = ConfigurationManager.AppSettings["accessKeyId"];
            itemLookup.AssociateTag = ConfigurationManager.AppSettings["associateTag"];

            ItemLookupResponse response = amazonClient.ItemLookup(itemLookup);
            return response;
        }


        public ItemSearchResponse ItemSearch(string SearchIndex, string[] Group, string Keywords)
        {
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.MaxBufferSize = int.MaxValue;

            AWSECommerceServicePortTypeClient amazonClient = new AWSECommerceServicePortTypeClient(
                        binding,
                        new EndpointAddress("https://webservices.amazon.com/onca/soap?Service=AWSECommerceService"));
            // add authentication to the ECS client
            amazonClient.ChannelFactory.Endpoint.Behaviors.Add(new AmazonSigningEndpointBehavior(ConfigurationManager.AppSettings["accessKeyId"], ConfigurationManager.AppSettings["secretKey"]));

            ItemSearchRequest search = new ItemSearchRequest();
            search.SearchIndex = SearchIndex;
            search.ResponseGroup = Group;
            search.Keywords = Keywords;


            ItemSearch itemSearch = new ItemSearch();
            itemSearch.Request = new ItemSearchRequest[] { search };
            itemSearch.AWSAccessKeyId = ConfigurationManager.AppSettings["accessKeyId"];
            itemSearch.AssociateTag = ConfigurationManager.AppSettings["associateTag"];

            ItemSearchResponse response = amazonClient.ItemSearch(itemSearch);
            return response;
        }

    }
}