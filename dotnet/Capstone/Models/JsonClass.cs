﻿using Newtonsoft.Json;
using RestSharp.Deserializers;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Capstone.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class AddressJson
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string state { get; set; }
    }

    public class AddressComponents
    {
        public string zip { get; set; }
        public string streetName { get; set; }
        public string preType { get; set; }
        public string city { get; set; }
        public string preDirection { get; set; }
        public string suffixDirection { get; set; }
        public string fromAddress { get; set; }
        public string state { get; set; }
        public string suffixType { get; set; }
        public string toAddress { get; set; }
        public string suffixQualifier { get; set; }
        public string preQualifier { get; set; }
    }

    public class Coordinates
    {
        public double x { get; set; }
        public double y { get; set; }


    }

    public class AddressMatch
    {
        public TigerLine tigerLine { get; set; }
        public Coordinates coordinates { get; set; }
        public AddressComponents addressComponents { get; set; }
        public string matchedAddress { get; set; }
    }

    public class Benchmark
    {
        public bool isDefault { get; set; }
        public string benchmarkDescription { get; set; }
        public string id { get; set; }
        public string benchmarkName { get; set; }
    }
    public class Input
    {
        public Address address { get; set; }
        public Benchmark benchmark { get; set; }
    }
    public class DadJoke
    {
        public string Id { get; set; }
        public string Joke { get; set; }
    }

    public class Result
    {
        [DeserializeAs(Name = "result")]
        public Input input { get; set; }
        public List<AddressMatch> addressMatches { get; set; }
    }

    public class Root
    {
        public Result result { get; set; }
    }

    public class TigerLine
    {
        public string side { get; set; }
        public string tigerLineId { get; set; }
    }



}
