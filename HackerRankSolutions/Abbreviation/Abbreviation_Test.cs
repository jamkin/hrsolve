using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankSolutions.Abbreviation
{
    [TestClass]
    public class Abbreviation_Test
    {
        private const int MaxMs = 250;

        [TestMethod]
        public void TwoEmpties()
        {
            string a = string.Empty, b = string.Empty;
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void NonEmptySourceWithAllLowerCaseAndEmptyTarget()
        {
            string a = "xy", b = string.Empty;
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void NonEmptySourceWithSomeUpperCaseAndEmptyTarget()
        {
            string a = "yZ", b = string.Empty;
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void SourceEqualsTarget()
        {
            string a = "xYz", b = a;
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void SourceMinusLowerCaseEqualsTarget()
        {
            string a = "XxYyy", b = "XY";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void SourcePlusUpperCaseEqualsTarget()
        {
            string a = "xyz", b = "XYZ";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void SourcePlusOneUpperCaseMinusOneLowerCaseEqualsTarget()
        {
            string a = "xy", b = "Y";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void SampleInput()
        {
            string a = "daBcd", b = "ABC";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void RemoveLowerInsteadOfCapitalize()
        {
            string a = "aAb", b = "Ab";
            Assert.IsTrue(Abbreviation.Solve(a, b));

            a = "aaAb";
            b = "Ab";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void DeleteSomeLowersAndCapitalizeSome()
        {
            string a = "abAxxaBa", b = "ABA";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TooManyCaps()
        {
            string a = "aBAxxaBA", b = "ABA";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void Useful_0()
        {
            string a = "ababbaAbAB";
            string b = "AABABB";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void Useful_1()
        {
            string a = "aAbAb";
            string b = "ABAB";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void Useful_2()
        {
            string a = "baaBa";
            string b = "BAAA";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void Useful_3()
        {
            string a = "abAAb";
            string b = "AAA";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void Useful_4()
        {
            string a = "babaABbbAb";
            string b = "ABAA";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void DoesntErrorOut()
        {
            List<string> strs = new List<string>()
            {
                "x", "X", "xx", "xX", "xy", "xY", "XY", "xxx", "xxy", "xyx", "yxx", "xXx", "XXx", "xYx", "YYx", "XYX", "XXY", "xyXYxyXYXXXXYZYx"
            };
            var pairs = strs.SelectMany(s1 => strs.Select(s2 => new { s1, s2 }));
            foreach (var pair in pairs)
            {
                try
                {
                    Abbreviation.Solve(pair.s1, pair.s2);
                }
                catch (Exception e)
                {
                    Assert.Fail($"Exception on pair {pair.s1}, {pair.s2}: {e.Message}");
                }
            }

        }

        [TestMethod]
        public void TestCase_3_Line_0()
        {
            string a = "LLZOSYAMQRMBTZXTQMQcKGLR";
            string b = "LLZOSYAMBTZXMQKLR";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TestCase_3_Line_1()
        {
            string a = "MGYXKOVSMAHKOLAZZKWXKS", b = "MGXKOVSAHKOLZKKDP";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TestCase_3_Line_2()
        {
            string a = "VLKHNlpsrlrvfxftslslrrh", b = "VLKHN";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TestCase_3_Line_3()
        {
            string a = "OQSVONTNZMDJAVRZAZCVPKh";
            string b = "OSVONTNZMDJAVRZAZCVPK";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TestCase_3_Line_4()
        {
            string a = "AXbosoh", b = "AX";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TestCase_3_Line_5()
        {
            string a = "EYONDOCHNZYYlBZXPGzX";
            string b = "EYONDOCHNZYYBZXPGXOG";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TestCase_6_Line_0()
        {
            string a = "OKXAJYPrZKNRQCLFKXJPJBXAEHYKXLIEIHLQYZPUNGELNKOZHsVLCPCXYSBURPRAWBAXBZBFBhCWBRNsTUNZIKriNYYPFXRNODZPCKNTTPCCZqvajmjtgxjjeafposdovrrzhkwesukvmlwbdzzlvvzyigpfvrhytcxpmbdytlkfzvnjnddpxxotsjfeuxdvmihwadpigjejtuyyrocbtlklkbsndmrpmekreqbbbznnyayzhvyjwlfqmxperliiforxddhwvectqoryxgvomhtjgizwdokbkrsbohupmkwcleetukcivqdbedyajoyglnaqzicuikmrjclfokypugvfgdfbdwpnccztmxwnyxdqrccrgoajwpyeeooesjvluyqdygiovqsrpudcjpriirnophewxcejanrbuqndxikaudmcaynpqmqpbhxwmfwuwwbvalglktmbbnleagsncvqgyduqclvnipxjkctqzatziewlccbyrukvnwuamahovdouwakuokwucexhmqvsilmsjgkqqwenmnxcyvjwjwqmflcpsjdjvagreajsmqjnpqjombmrhnvexfjsldjvapitqyajbypzqbrkladxfqiwsbwbm";
            string b = "OKXAJYPZKNRQCLFKXJPJBXAEHYKXLIEIHLQYZPUNGELNKOZHVLCPCXYSBURPRAWBAXBZBFBCWBRNTUNZIKNYYPFXRNODZPCKNTTPCCZ";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TestCase_6_Line_1()
        {
            string a = "ZTLIvFUYHQXJJXOGUSOQMQULQXXIJJNSTAEaNGPMXGDMXYINbBKSGAPQWRJELeBFHXDSRFONZJRZVSQAkARSJUYGAJCZLHESLCISMQDUCYKAIKWQYCmPSRRiEVvSEYNMDBXGHCBEFTvFBPDDWGWMVLUQKUJFEAAOTDSOYZCXbCNXWRSACFPEBQFTJWFPNJvXYOKZTLGWzVxBChKLHzDBPXDUKLYOAIXYARSHYSTTZVDNWYDOiZxLgOYZVKYAfXJNXQUAFCHVSQAAIMPRNQNRXDPOSHIXVYCRRCLAKZRKMVMGKXLWCcSDDhSLLkMPKYVSCMSPHeuwtmakggqjednmhlcnikewdoyfipgkrygyswcyupdqjxpihgkvtofqjtmwkoqmqyowlqbngxohxgupknkjpdnrvzmdorpljnffvxxzbrpolnawqlhhaeljudqsnclfwffgnjkevqlqsjblmmxkzrfcyriubmfwggpwgcygwnhhncmyajdieabqmckqtloolhbezweycglmzoshpfoecvafgxh";
            string b = "ZTLIFUYHQXJJXOGUSOQMQULQXXIJJNSTAENGPMXGDMXYINBKSGAPQWRJELBFHXDSRFONZJRZVSQAARSJUYGAJCZLHESLCISMQDUCYKAIKWQYCPSRREVSEYNMDBXGHCBEFTFBPDDWGWMVLUQKUJFEAAOTDSOYZCXCNXWRSACFPEBQFTJWFPNJXYOKZTLGWVBCKLHDBPXDUKLYOAIXYARSHYSTTZVDNWYDOZLOYZVKYAXJNXQUAFCHVSQAAIMPRNQNRXDPOSHIXVYCRRCLAKZRKMVMGKXLWCSDDSLLMPKYVSCMSPH";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TestCase_6_Line_2()
        {
            string a = "HSIOCQYGXOZBHKTVEXDLTNTLAMPDLOYRZZECYKVLKHYLGRHZBYMLPRIDJVWOMLDUYNUXBIGKRFJSUGZZIXHYNENHVZESEPKOGNCWQXDVEQANBTARFDLFRQPWUKLOATLCBZNENEZYAKBMMFUUKDIWOUGMGJLLBENJCSNCAMGOGIBOGTSPPDDUBNOTZYFNNFYZHGZLQZIJYYYQPOATXZEOOUGDELMPOSNGUFPMISGRIWRTUTZJTFGPUSEEKRIFPKZZYMKBACEMNPAYSIFVTDCWOHGQTEYSPADCMFXRKJRZTBDGJSDCGWQIMBWNPYSCYEIBEQYLVSLGFHBRKPNOKBFNOLGKkimfisbnsmbjnabmrlupqhahcveruwfurfxwiaftdpyuwdjjowtwetimhqvyylpbykfhxlnuyzlzcfgymsmjxbzcfyfwmirpeshsfcwnpgupirxldxrvwqdsanesnkqydhhpfcznisofyltvxikbcudfofjdfgriydlpmkhzipnhkijhbbnglwstpcxxwhjrcctacpwdokcehmfloweknorwgluliqjihitojpdbpnxebdcfswliqgzutstadpslnmxqgzmvvumokpmpkrsdpitdccjtpjtepibzanpgyxndmyktxvknbiwcbgausnbcmygjztfczkfthzaqjigfebrhttrnughxskbpjxkfrqgzzudkoiiqkfzrjzilvdufmgaqfzqmogfsdsgmtzrmcx";
            string b = "HSIOCQYGXOZBHKTVEXDLTNTLAMPDLOYRZZECYKVLKHYLGRHZBYMLPRIDJVWOMLDUYNUXBIGKRFJSUGZZIXHYNENHVZESEPKOGNCWQXDVEQANBTARFDLFRQPWUKLOATLCBZNENEZYAKBMMFUUKDIWOUGMGJLLBENJCSNCAMGOGIBOGTSPPDDUBNOTZYFNNFYZHGZLQZIJYYYQPOATXZEOOUGDELMPOSNGUFPMISGRIWRTUTZJTFGPUSEEKRIFPKZZYMKBACEMNPAYSIFVTDCWOHGQTEYSPADCMFXRKJRZTBDGJSDCGWQIMBWNPYSCYEIBEQYLVSLGFHBRKPNOKBFNOLGK";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TestCase_6_Line_3()
        {
            string a = "HSIOCQYGXOZBHKTVEXDLTNTLAMPDLOYRZZECYKVLKHYLGRHZBYMLPRIDJVWOMLDUYNUXBIGKRFJSUGZZIXHYNENHVZESEPKOGNCWQXDVEQANBTARFDLFRQPWUKLOATLCBZNENEZYAKBMMFUUKDIWOUGMGJLLBENJCSNCAMGOGIBOGTSPPDDUBNOTZYFNNFYZHGZLQZIJYYYQPOATXZEOOUGDELMPOSNGUFPMISGRIWRTUTZJTFGPUSEEKRIFPKZZYMKBACEMNPAYSIFVTDCWOHGQTEYSPADCMFXRKJRZTBDGJSDCGWQIMBWNPYSCYEIBEQYLVSLGFHBRKPNOKBFNOLGKkimfisbnsmbjnabmrlupqhahcveruwfurfxwiaftdpyuwdjjowtwetimhqvyylpbykfhxlnuyzlzcfgymsmjxbzcfyfwmirpeshsfcwnpgupirxldxrvwqdsanesnkqydhhpfcznisofyltvxikbcudfofjdfgriydlpmkhzipnhkijhbbnglwstpcxxwhjrcctacpwdokcehmfloweknorwgluliqjihitojpdbpnxebdcfswliqgzutstadpslnmxqgzmvvumokpmpkrsdpitdccjtpjtepibzanpgyxndmyktxvknbiwcbgausnbcmygjztfczkfthzaqjigfebrhttrnughxskbpjxkfrqgzzudkoiiqkfzrjzilvdufmgaqfzqmogfsdsgmtzrmcx";
            string b = "HSIOCQYGXOZBHKTVEXDLTNTLAMPDLOYRZZECYKVLKHYLGRHZBYMLPRIDJVWOMLDUYNUXBIGKRFJSUGZZIXHYNENHVZESEPKOGNCWQXDVEQANBTARFDLFRQPWUKLOATLCBZNENEZYAKBMMFUUKDIWOUGMGJLLBENJCSNCAMGOGIBOGTSPPDDUBNOTZYFNNFYZHGZLQZIJYYYQPOATXZEOOUGDELMPOSNGUFPMISGRIWRTUTZJTFGPUSEEKRIFPKZZYMKBACEMNPAYSIFVTDCWOHGQTEYSPADCMFXRKJRZTBDGJSDCGWQIMBWNPYSCYEIBEQYLVSLGFHBRKPNOKBFNOLGK";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        public void TestCase_6_Line_4()
        {
            string a = "AUPWLXERCIJHJQWCYHRXNNZHCHUEZANZBDOHvFWMFLSHYDKOWYUFaMUPVXSXWMZPBdIRQMUUKOGSHCHLHOUABMQQYZXNSXBVVEWWASISFlwrxpnrzxwhzrzdolsbzgnvjjtbymtuwbbqpnxzbftjnuyeckeqfdckrlwoddspwishemlxvonzdwvzvopalzgpaiaxeemsgmhyknhakijyeluemwwfxktuauzoitxqkcxohcjdqjzbylkmgrkinvdanumnxsvlyrmneslsjegscjtylpubuwyejfgjwqeuzifjfizkunziybvtbxfuvjwamfsrqjxcyslivxrqjjrcwbejomhdqwtnkgqvvtkhvbxcdkhepprbavaszgnzmjganwllewzcmaqcvlbhjdidmrzhtmfakjapfufcfyiwiqfkaxwsbidasqvuqcameeznspfbwwqavtbzuwkphghmdcehgfwwciclcntivejjvubtxeqfrrhyitjeyrccplfcaisyauhhtrsqjnobywsoevyGcgmdsgddyoohcduamcveluipoygvoxgiwVotgrjjudvsbbkwmpqojyazbwdjcvznnvliklzzjzhjixbhgpzfstoaersuwrfmdnageiwnolmr";
            string b = "AUPWLXERCIJHJQWCYHRXNNZHCHUEZANZBDOHFWMFLSHYDKOWYFMUPVXSXWMZPBIRQMUUKGSHCHLHOUAMQQYZXNSXBVVEWWASISFIWEKZRXOOOOZIFNZZSFTMZNQXDTDDAZRRFNDHBLGLOMHDWZTLEJEAJVSCGWZJGACFBLFWUJKYCVKKKVWZNLZZUIZEUXDFZYZMSEKALACDOIRQEFZZJYAITCLRWISKCCOTFPESTJUQOXREDUSFPOIHOYUXNNLEKUDAUGSHZGOEHMTXLEPXXQDTKFCNZYPUSRUNFLUHTVWJHFFHZXSUPLGSEGQPKFLUFRRYLSTMERSNWASKGWDLOVYRUDCMCKSWDZDJGCHPTZVBBVRTCGFHYIFOOEQFGRRRPEMUYTWZCSRIIYTZWQMNVYUMBUCCHEKESIFQZUROMUAKFGJYHDKGSZEARUALEIYSQINNIYAFECPJLGFCWMZMRDIAIYGKZSSPEETDXRMPALQEWMEZLUDOOQVDOYASGYCJKAIQOKXATOWJGVJRWNLOYIBRHVLXBZXJFHIPGTAYMEPMMINCPFVUBRNMPMDTTIPWWCCZFCCSFUNKSTDFVFYFNIOTMGQUUHOWTCGSVVTcdyowhbzcpkvkgriqcfoyydwhfemurlhmbjwprtxjmfbrlqaqqrvansmmgkfjwqiueyeydshcgaajvuancjvbsrkaxxptjobepylgjmpozqllisdsvuyfsuzfcryuc";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_11_Line_0()
        {
            string a = "bBccC", b = "BBC";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_12_Line_0()
        {
            string a = "hHhAhhcahhacaccacccahhchhcHcahaahhchhhchaachcaCchhchcaccccchhhcaahhhhcaacchccCaahhaahachhacaahhaachhhaaaCalhhchaccaAahHcchcazhachhhaaahaahhaacchAahccacahahhcHhccahaachAchahacaahcahacaahcahacaHhccccaahaahacaachcchhahhacchahhhaahcacacachhahchcaAhhcaahchHhhaacHcacahaccccaaahacCHhChchhhahhchcahaaCccccahhcaachhhacaaahcaaaccccaacaaHachaahcchaahhchhhcahahahhcaachhchacahhahahahAahaAcchahaahcaaaaahhChacahcacachacahcchHcaahchhcahaachnachhhhcachchahhhacHhCcaHhhhcaCccccaaahcahacahchahcaachcchaachahhhhhhhhcahhacacCcchahccaaaaaHhhccaAaaaCchahhccaahhacaccchhcahhcahaahhgacahcahhchcaaAccchahhhaahhccaaHcchaccacahHahChachhcaaacAhacacaacacchhchchacchchcacchachacaahachccchhhaccahcacchaccaahaaaccccccaaaaaaaHhcahcchmcHchcchaaahaccchaaachchHahcaccaaccahcacacahAhaacaacaccaccaaacahhhcacAhaCchcaacCcccachhchchcchhchahchchahchchhchcacaachahhccacachaAhaaachchhchchchhaachahaahahachhaaaccacahhcacchhhaaachaaacAahhcachchachhhcacchacaaChCahhhccahChaachhcahacchanaaacchhhccacacchcahccchAcahacaaachhacchachccaaHacaacAhahcCh";
            string b = "HAHHCHAACCCAHCHHAHHAHCACCHCCHHCAAHHCACCCAHHHACAAHHHHCHHCAHHAHHAAAHAACAAHAHHCAHAHACHACHCHACACHAAHHAAAHCAHHACACAACHHHCHAHCAHCHHHAHAHACCAAAHCHHCHHCCAACCCCAACHACAACAAHACHCHAHHACCHCAHHHAAACHACAACHCACACAHHCCHAHACCCACCAACHCHHHCCCCCHCCAHHCAAHHAHHHHHHHAACCCCAHCCAAAAAHHHAAAACCAHHCAHACACCHHCHAHAHHCHAACHHHHHCCHCCAHAHCHCAAACCACCCCHACCACHHACHHACACHACCAACCCCAAAAHHAHCHHHCCAHCCHACHHAHCCACACCHAHAAACACCCCAHCCAHACCCCCCHCCHHCHHHHCHCHCAHHHACHAHAACCCAAAACHAACAAAHHAAHAAAHACHHCACHCCHCHAACHACACHHCCCCCAHCACHAAAHCHCAHACAAC";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_12_Line_1()
        {
            string a = "XbxxobxBobbbxooXobXxxBOXoOboxxbobXOoBbxbXooXBboxooOxxXbboxoOxlobbObbXoXXbbXobbbXoxbxXBxoobooxbxoxoxOxxOxbxbxXobbbbBbxoxoooxooobXxbooBbOXxXxbxqobbbboXxoXXbbbxObXXxobOXXOxoOoxoXOXBxOxBoxbobxoBxbobobXooOxxOBXbxxXbooxbxooOxoxoobxxBOxxbbbxBxzXxbBxOobBObooofbbBXXOxxoxxbXBbOboxxooBbxOoboXoooXBbBbooOoBbbObxobxbBBoOxoxobBoOXXobObxobxOObobbbxxoboxoXxbXoxxxxbbobbXoXooBXXxboxbobxxxXboxOoOoxBoboOXboBoobXobxXdxObbbBxbxBbOOXbxooXboxboonxxxXOBbbXXoobooxbbxboxoOxBBbxBOxoobXbbxxbXXObxBbxBXBxoxOxoBbxBobOXbboxooBxbooXbXbooBbbxXboxXbxXoxbboxOXOooXbobooXXoxobbxoOxOoBbxxoBboboxoOBBxoboBoOboxbbxxbbbObXbboXbObOjXOXBxbxXobbbboBxBoOooxbxxOooxxbxxobbobxbbXoOobbBXoObxobXxoobxBxBbxoobXxoxObboxobobooxOoooBBbbbxxXoxbXxoXooxOBxboobxooxXOxobXoXmObxxXObooXXXboOXxbXxObxxbbObObxbxxbxxBXxBxoxOooaxooxXBXoXOxoOXxbBoBXxXooboXboOooxoxOxXxbxoboOObbBoXxbboxxooBBbooxXBbBoxBOobbboobobooxoxOxoXOXXboxXOboBxoboOooxbxBxobooXOoxOOObbxbobxxoxbOBoBxboxoobbbxoooxBxoobBbobBbooOBbxoboooookxXoobbbbBbOoxOBOobXObXBxoXoboxobbXBXBBoxBxoxooOxobxo";
            string b = "XBOBBOBOXOXBOXOOBOXOXOBBXOXBXOXXBBOBXOXXXOBBXBOOOXXOXBBBXOXOOOXXOBBOXXOBBXXXOXXXOXXOOXOXBOBBBXBBXOOXOBXXOOOOBXBOXXBXBXXXBXOBBOBBXXOXXBOBBXOXXBBOOOBBBOXBBBOXXBXXOBOBXOOOXXXXXXOBXXBOXXOOOOBOOOXBBOOBXOXXOBBBBOOXXOOXXXOBBXXOXBBOXOXBBBOXOBXXXBXXOBBXBOOBBBOXBBBOXBXBOBBXXXOXBOOXOOXBOXXOOOOBBBBOOBBOBOOBOBXBBOXBOBOXOXBXOBBOBBOXBOOXXBBBBBXOBXOBXXXBBBXOOBOOOXOOBBBXXOXXOXOBOXOBXXOXOOXXXOXXOBOOXBBXBOXBXXOXOXBOBXXOOXOOOXXBOOBBXXXBBOXBBXBOBBOOBOOXOXXBXOBOOOXBOXOOXOOOBBOBBOOOBBBBBOOBOXBBBOBOBXOXBXOBXBXBXBBBXOOO";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_12_Line_2()
        {
            string a = "laalsAsaasLbbabLslalBbssaAsAlSLsbBllsSalblsssbsaaaAsabBaaAaalsssasssssLbasbbllbbLSsslbabAbSlllsbsbbalbBaSaaalbslaabAAaaabsabSlsassSshBBllbAAllsSbaLblabsaLBasBsAlLaabBbAllbaslsllsaAaAabbSallbLalsslbbblbasBAsbaBLalbBssbbAlbbbsSlsllbaLBLaaLblalBSbsBbSsbbaaSlllsblbsSaaBbassslaalblBbslLlaASASbbabbLlbalSabbBbLsbaabbalsAAbSbBbABbabbabaallBsasllbsbbsslSsbBlBlbabaalblaLsllbasasalabllSsbslLbsllbLsBlaSbssSAbsSasbsSalsabbllbbaBSBlabsBlAsbaSLbSllbsAblllSLaaAlBssSsBSLslAAlsbslbalsbSbsbalbsBabSbbsssaaabassalslllbsSLSsaLlbbBslSlSbbslsbslSLbbSbAaaaalLlSlAslsbmslbbalblLabSslassBabllSAsbbsvLllSalalbsaaaLAaSSbLbblaaSbLaalABlabsAsBsalssbBLlsLssaabsslabpSbsBaBbbSBlsaaabbblslBAblsLaASlaAlbaaSssbblalAaasbaalbLlaabbAaaaaAalsabbsllaaAsallsasBbAaslbbsbllbbllbslaBASbbSblaAbbsbbssAaBbsasLllalBlslssasbssBALAasbbsbSfasabbllbAslbalbaSSlslbbSbsaBsAalablAbbaBBsbsSbdaAsBblsblbABbLAssAbalsbssSssbBBssAsABLssblsLbllSblasllLbBsassllBbBbsbBsbllsBBsAbbLLlAslBlsAAASlaalabasaLslasBLlsslsaaslsbblbAsalSlllsLSAaLlalAalsBsaslaaaalb";
            string b = "ALASALABLABBASASLSBLSSLSSASBBAASSSLBBLLSSBAASLBBASBSLAAASSSSSBBLAALSALLBASBALLBBABASLLSAAAASLBBABABLABBALBSALBLLLBSSBSSAASSBBALALBBBSLLLASASLASABBBLASAASBBABAAALBLLBSSBBLBLBLLLAALLLSSSLLSLLBSSSABSSSSSBABSBLASBASSLBSLSASLAALBSBSLAASBSSBBSBBSSLLBSLSSLLBBLSLSSLBBSAALSASLSLBSABALSASLLLSLLAASSLBASBLAAABBABSBLLASASSBABBSBBBBLBABSLAASAASSSBLALAAASBLLBBAAABBLAABASSBBBLBLABASBSLAABBBSAABBASLLBSSSBBALASBSSBBASSLSBABABBBSSAABBLBABLAAABSBBSAABLSSSLSLLBALBBBBBSBBSABLLABLSAAASLABAALSABLSLBLBASASLLSALAABAAAALB";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_12_Line_3()
        {
            string a = "EerRrrreeReeeErEEEEeRErerrrreeeerreerRrrEeeeReerrrrErereeRRRrREReERrEerREeEsrrrREeErererrRreERrrErreeeEEeReRrerrrERrreeerrrreEerrerreRerrRerRererrereeeerrrrReRRRrRreerrererReRererRrRRerRRreRRrRrrrEeRrrEEeeEeerErrereErEerreeeREererrRRERrerrrrreEerRrrrEeRERreereeereErerrrrrererErerErREEereReeeEeerRrerrrrrrreerErreEReeererrreeeeeeeEereErreerEerrerERrrereeEeREeRerErErreRrrrRrreEERrrRErrRreeEeEeeeerreRerRreEReeEeRERRreReEeerEErrrERreeErerEeERrRrrReerrreeeEerrerrrerrrrreeerreEerReRRErEerreerReeeeerrRrrrrrreerRreeEEereeeeErrrrrererErREeRrrReerrErEeEeerRreeeeeRrERerRrrererreReerereeerreRreeereERrrErreeeeerrrrrEReErrRerrErereEeerrrerrEerreEeererRererReeeErEereeRrrerreEeRrrRrrErrEereRreeereErRerereeeeRrRrreeerrrereereeERrRrrrRRrrRReerEEEReerRrererREereerRrrerrEeeererRrERreEreRrrRreerReRerreereRRreeERrEeEreErEreERrerEerrereEeerereerrEREeeEerserrrrreeRrRerrrERreEersEReREEerRrerrrReErrRerreReerererrrRErrsEErrErEEerrEREreeErrrEereRrrErRereeerREeEeEeerrrererrrRrRrEreERrrrerEerrrRRrerreereeRereerreeee";
            string b = "ERREREEEEEEREERREEERERRERRRERERRRRREREEREERREEERRREERERERRERREEERRRERRRRERRERRRRREERRRRRRRRRRRRERRRRRRERRRREERREEEEEREERERREEERRRERERERRERERRERRREEERREEEEREEEERRRREERERREREEEEEEEREREEEEREEREREEERRRREERREREEEEERREREERERRREEEEERREREEREEERRRRERERRRRREERERRRERERRRRERRREEREERRERERRREREERREERERRRREREREERRERERERERERRREEEEERREREERERRERREREERRREEERRREREREERERREEEERRRRRRREEERERREEEREERREREERRRRRRERRERREEREEREEERRREREEREREREEERERRERERERSERREERREREERRERREREREEREREEEREEREERERREREEEREEEERRERRREERRERERRREEEREE";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_12_Line_4()
        {
            string a = "YYRlYyrYYrLYYyrllRLzrLLRrRylyylrRRyYYLLYllyyLllyLrLrYlrryRsYYYYYlyRrrrRlRRrLlyrlLLLRYlrrrrrlrrylYRRLlllRyyYRlyyLYryrRyyryLiLylyryyrlRLLLrlLRLYrylYrLylyyRrLyyylYlLrrylYyrLLrwyRRylLRrllYRrrrYlLyyRLrLRlLLlLYLYYYlRyyYYRyrllrrlllyrLrlllLrylRRrLLrRRlyrrRRYyYlllyLrRLlRlrRrYyLLjyRLlLYyryYyrylrlrLyylRyryrLLyLYLyLYrYlLYrRRrlYlyrryRYllLLLyRrRRylLyYlYyRLRLlyRRlrrRRrlRlRlryRRyRYRrryYYYlYYrLlllYrlRRlryyllYyRlYyRLrRrLYYyLrrYllYRyLlylLlrlRlLlryLryRlYylRLYlLYrlyRrrrllYlYLLYRRrRRLLYLlYllYlyrLRylRYlLyLRLrRYLyRlmLLlYlLrRlLylLlrLYyyYYYrRlrrylyRylryrLryrlYrlLrYlyryryRLyLlYRlYyrYRyylryYRryyylRylryRRyllrlllYrYRrrlYyRRyrYlYpylRrRYRLyRRRrrrYRLylrlRyyRlylYLYYRYlryLlRLYyRLLYyllRlRlRlyylRYRlLlYlyRlYrYRYLyYRyRLrRYrYrLYyYYlRryrrlylYyrlRrryYllnRLyYlYryrRLlYyLryylYyRRYLrLlyrYlRLlRLryrylLLRLrlYYyLrLyrYLyLrYlYYrYYlrLrllYlllYYlrlRyYRyLRRRrLrlLyRLRRLrLRrLyLRYRLYyRLLyRRlRLllyrYlRllrLlLyLrLYlryYYlLyLlRRRrfyLLrlRlyYRLrYyYyYylyyyryllYLRRrLrylYlyRyYLlnrYrLyRRRyRYYYrYrRlyLryyrrrlygrrRRyRYRyrRRllRlrYlRylryLryylrryYlYlyrllLllyYYY";
            string b = "YYRYYYLYYRLLLRRLRRYYLLYLLLLYYRYYYYYLRRRRLLLLRYRYRRLLRYRYLYRLLLRRLLLLRLYYLRLYLYLLRRLRLYRYLRLLRLLLLYLYYYRYYRLLRRLLRRLRRYYLLRLRLRYLLRLLYRYLRLLLYLLYYLYRRYRYLLLRRRLYYRLRLYRRRRRRYRRRYRRYYYYYLYRRRYRYYRLRLYYLRYYRLLLRLLRYYRLYLYRRRYYLLYRRRRLLYLLYYYLRRYLLRLRYLRLLYLRLLLYYYYRRRLYLLYRLLYRYYRYRRLRRLYYRYYRRRYYLRRYRLRRRYRLRRYLYYRYLRLRLYRLLYRRRRYRLLYLRYYRYLYRRLRRYYLYYYLRYYRYYRLYYRRLYLYRRYLLYRLRLLLRLYYLRLYLLYYYYYLLYYYRYRLRRRLLRLRRLLRLLRYRLYRLLRRRLYRYRLLLLYYYLLLRRRLLRYRLYYYYLRRLYRYLLYLRRRRYYYYRRLRRRRYRRRRRYRLYYLYYY";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_12_Line_5()
        {
            string a = "vvvkeevekVVvvkkKeeVvKvkevkvvkevevkeveekkkvekVkeEevVvkkKevekkkkekkekvevkevekkevEvEkEvvKkkveveKkKkkEekevkveKvkKkVeeEeeeekkekekvvkkvkeKvkKvkeKkKKEvvVekeKeKvvkeKvveeEEvkeveekVvekkkkevkkkkekVvvvkkEekkvkekVKvekVevvKkvvEveeekkEvevkekeveVkKevkVkeEvkeeEkkvekeevVvvvvkkvveKeevkkevvVekvKEEVvkvVkeVkEkkvvEekVkekevvVEEvvkKkkevEeVKvEekkVkVvkkevkvVeEeeeEvvkkkeVkeeVekEkeevkvVkKeevkKvkekvVevvvVkvKKKevekEvVekvEVeKkKKkvvevekvevkKvvvVvEEkEeveekKKVEKkkVKvKevkveVvVveeKVekEkkevvveveKeevkVvvEVeEkEkKkkeeeveeekekKeVvekevEKvkkkkVkEkekeEEekvkVVkekvKKkeeEvkeVkkekkvvKvKvEEVvvvVekkeeekEvvKvvvvVVEeeKVKvVekeekvvekvvekEeKekeEeVVEeeKEeEEvvveEevVEVkEvkeEkeveeeeevkkeVkVKvvvekeveKekeekvevkveEkKkkevEkKkvveKkkkvvEEvKKeVekVVkveeekEvkkvKvkvveEvKkvEvvveKKekevEeekKekkkkvKkkEvKkeEkvKvkevekVKVKvveKvkvvkkVvkvKEKvvvvkeekevkEVvKeKkkevVkkEEkkvkveVVvevevekkkeEevEkeVkeKkVekvEevkeeEvVKVeeVkVekkvevekEeKevvvkeevvvVevKvVevVvVkkevEeVkEvEvevEeevKkkevekkvEkvkvKkeveveekvveKvKeeeeekEkEkKeKkkkvkEkekvEekeekkvvvekveekeeveKekeVevEVekkKKKvkekkkEvkeekke";
            string b = "VVVKEEVEKVVKKEEVVKEVKVVKEVEVKEVEEKKKVEKKEEVVKKEVEKKKKEKKEKVEVKEVEKKEVVKVVKKVEVEKKKEKEVKVEVKKEEEEEEKKEKEKVVKKVKEVKVKEKVVEKEEVVKEVVEEVKEVEEKVEKKKKEVKKKKEKVVVKKEKKVKEKVEKEVVKVVVEEEKKVEVKEKEVEKEVKKEVKEEKKVEKEEVVVVVKKVVEEEVKKEVVEKVVKVKEKKKVVEKKEKEVVVVKKKEVEVEKKKVKKEVKVEEEEVVKKKEKEEEKKEEVKVKEEVKVKEKVEVVVKVEVEKVEKVEKKVVEVEKVEVKVVVVKEVEEKKKVEVKVEVVEEEKKKEVVVEVEEEVKVVEKKKKEEEVEEEKEKEVEKEVVKKKKKKEKEEKVKKEKVKEEVKEKKEKKVVVVVVVEKKEEEKVVVVVVEEVEKEEKVVEKVVEKEEKEEEEEVVVEEVKVKEKEVEEEEEVKKEKVVVEKEVEEKEEKVEVKVEKKKEVKKVVEKKKVVVEEKKVEEEKVKKVVKVVEVKVVVVEEKEVEEKEKKKKVKKVKEKVVKEVEKVVEVKVVKKVKVVVVVKEEKEVKVEKKEVKKKKVKVEVEVEVEKKKEEVKEKEKEKVEVKEEVEEKEKKVEVEKEEVVVKEEVVVEVVEVVKKEVEKVVEVEEVKKEVEKKVKVKVKEVEVEEKVVEVEEEEEKKKEKKKVKKEKVEKEEKKVVVEKVEEKEEVEEKEEVEKKVKEKKKVKEEKKE";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_12_Line_6()
        {
            string a = "RreeerrEeRReReErrrReerresrERrrrReTrreEerRRerRrereeSeeererEeEeeErEREErrErrreeeerRerrrrRerEREeererSeRrReRerrrerrErEReeerrrrrReEreerReerRerREERreeeeRreReeeeeEErRRrrererreRreReeereRrerreRrREEeReEErrrreeErEeReRrrerrrEreereereeRrEeRrreREeeerEReREerrrrreerErEErrrrRErrrRrreeReReereERerereReRreEeeeeEEeerrrerRrrrrRerreeeEEereeereeEeeEseeReEreRRERrrrereerrererrEReerrrrrreeeRrreeeeeRRrsrrREererERRreereeRereEeRrRrRereEeeeRreEeerrRrereRerrrerererErRererrreeEeRRrErErrErrerrrreerrrreReeererersreReerEreRerReRRreEeeReereeEerrEEErrrEererreeerreeerrrrrEeeEEerrrReReeerreeREeEeREeReeeeREeRerERerreRereeslrrreeerERerErrRreRRrreEeererrrRRRreErrRREreeEeereeerrreeerrEerrrRRrerrerRReErRRrreEeeRereeEeERreEeEerREErReReRerrrreeERErereRreeReeeeeeErrreeerEeerEREeeReereerrrrerrErerrErerRrrErerrReEEerReeERRRrErereeeerERerRrRErSeEeeeeRrEereeeErrrREerERerReeeeReerRrreeEEeEerrereeeererEEERseeererRrrRerreersereeeRrreeEerrrrrreRERrErerrreRrrererRerererRreErEErrRrREreRrRrerReEeRrErrerererrreerreEReeRererrreReEEererREeEvRRrrer";
            string b = "REEERRRERERERRRRETRERRRRRERESEEEEEEEREREEEERRRRRERERSRRRERRREEREERRREERREEREREEEERRRRRRREREEEREERRRREERRERRREEERRERREEEEERRRRERRRREEERRRREEEEEEERRRRREEEEEEEEEEESRERRERRRRRERRRERRRRRREREREEREERRRREREEREERRRERERRREERREERERRERRRESERERRRERREREEEEEEREERERREEREEEERREREEEREEERERRERRERREEEEERERRRRREERRRREERRRREEERERREEERRRRRERRREREEEREEEREERREREREEREEREEEERREEREEEREREEREERERRERRERRREEEERREERRREREERERRRERSEEEEREERERREERERERREEEREEREEERSERRREREEERREERRRRERERREERERERREEREERRRERRREEREEEREEREERERREEEEREEERRR";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_12_Line_7()
        {
            string a = "ANzaNanaanAZnnaazzzNAznnZaaZzzaZzzznaaaaZAANnaaanZnzazaAANanZaznazznzaAaNznazzanaZznzANzznzaaZzAnanNanzzAazzZZananazAznaznNznaAAaZnnanzazANAANAnnnzazaaaanzaznAaaNZnNAnnanazaZzNzazanZnazaAzanazzaNznNzzzaaanZaAnNAanzznNaNznanAnananNnaazznznnzNznnNzzanzAaNzzzZzAnnznaanzZznzNZzZzznnnaazzzanaazzazznnanANnznzAZzNZnNnanzazNaZZzzazAnNzAzAZAazanzzZzaznnZzaaazzznnaanaazaAnzzzZaaazzzzNaaNazzaaANznazAannzAaZZaznnzznnAzaaaanaaAznazZAnzzaAzaZzzZzznzazAznnaznznnaNAazZzzazNazanzaanZaZznnznzaNzannnZZNnaznzaNaAZznazAzAzNnnanznannaznAznnnnazzNnaazAanzZnaAnnaAzaanZnZNNzannanznazAnzNanaZznAAnnnNzaznAnZZnznaanzzaNzzAZzaNzNzaZanaNzNnnnAnaaZnaaznanZnzaannanzAzazazaNannaaznNnNnzaazazAzAnAzzaNaaNnanzaaZANaaZnaAzazaZZZAznAaaZnaAnnAanaAAnznNNzNnanZzzZzzNzaZaaznnznzNnaNZannNzAnnnznAazaaaanZzzananznzzZznNNzzznnznannZzznzzaZazaNnnnZzanznazzazzanzazzZannzAzazAZnnzNZannzZaNznAZanaaanAnNzzznzZaanANZananzzZaNzzaZnnzazZanzznAaaAZZaznANNzanaaanNzAnaanaAzzZnNannznaNznANzznzZanaNNaZnzaznzZaanzznnnAANzzZananzNZnaaZaANZzNAAaz";
            string b = "ZAANAANNNAAZZZZNNAAZZAZZZNAAAANAAANNZAZAANAZNAZZNZAAZNAZZANAZNZZZNZAAZNANANZZAZZANANAZZNAZNZNAANNANZAZNNNZAZAAAANZAZNAANNNANAZAZZAZANNAZAZANAZZAZNZZZAAANANANZZNAZNANNANANNAAZZNZNNZZNNZZANZAZZZZNNZNAANZZNZZZZNNNAAZZZANAAZZAZZNNANNZNZZNNANZAZAZZAZNZZAZANZZZAZNNZAAAZZZNNAANAAZANZZZAAAZZZZAAAZZAAZNAZANNZAAZNNZZNNZAAAANAAZNAZNZZAZAZZZZNZAZZNNAZNZNNAAZZZAZAZANZAANAZNNZNZAZANNNNAZNZAAZNAZZZNNANZNANNAZNZNNNNAZZNAAZANZNANNAZAANNZANNANZNAZNZANAZNNNNZAZNNNZNAANZZAZZZAZZAANAZNNNNAANAAZNANNZAANNANZZAZAZAANNAAZNNNZAAZAZZNZZAAANANZAAAANAZAZAZNAANANNANANZNZNANZZZZZAAAZNNZNZNAANNZNNNZNAZAAAANZZANANZNZZZNZZZNNZNANNZZNZZAAZANNNZANZNAZZAZZANZAZZANNZZAZNNZANNZAZNANAAANNZZZNZAANANANZZAZZANNZAZANZZNAAAZNZANAAANZNAANAZZNANNZNAZNZZNZANAANZAZNZAANZZNNNZZANANZNAAAZAZ";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_12_Line_8()
        {
            string a = "evivevvVvevvEeeevVevevVvevEVevEeeEVVveevEvevevEeEeEEeeVevvvVVvevveevevEeVeVvvveeeeeivVveEevvEeveevvevvvVeevVeeeeveebveeVvvvvvEVEvEvvvvEEVVeeeVvEVEvevvevEvveVeEeeeVveVEVvvvvEeeVVvVeEEVvEEeeeveveeevVVeeeevVveeVvevVVevevvEEveVEEVVeeeEeveevevEvvvvevveeeeVEvevvEVvvvVevevvvveVeevVveevVeEevEEeeevVeieeeVvvvevvVeevvveeeevvVevEeevvvevveveevvveeeveeevVivevvevVvVeeevvEveevEEVeeVVEeeeevvveeEeveevvVeeEeevvvveeVvveveeeEveeeEeveeveVeVEveevvvVeevvveeEevVveeeVEeevEveevvVeveeeeVVVVeVEvvEVveveEvVeeeeEeeevvVEvveevvEeevevvVEeeeEvvvevvVvEVEvvvvvVvevEvVvVeevVevvVvEvveeeeeeEeveeVvEvVVvveveEvvVveeevvvViEeEEveeevvVevEveVVVeEeevVeveeEeeeeeveEvvVEeeEeveEvvvvveeVveVeVveeeVveEveeVvEVeEEeveeeVvvveEeveveeeVevevvveveVEEeveveevevveeevVeeeveveeveeveevvvEeeEvVeveevVEVEvvVVeeveVevViEEvVevevvVVEVVvvVeiEvVeevevvvEevvEvvvvevVveeVvvEevEeEEvEeeeeevveveevveveeeeVVeeveevvvveeVEEEveeeveeeEveeVVeeeVvEvvevveevvveVveeievivvVvvevevveeEeVEEeveveeVEEveviEveeivVvvVIEeEEvEveevEEveVvvEEveVeVEVvveveeVvVeEveeVVvveveeveVeveevvevEeVeeveVeEeVve";
            string b = "VEVVEEVEVVEVEEVVVEVEEEEEEEVVVEVEVEVVEEVEEEVVVEEVEEVVVEVEEVEEVVVVEVEVEVVEEVEEEEVEVVEEEVVVEEEVEEEVVEEVVVVVVEVVVVVEEVEEVVEEEVEVVVVEVEVEVEVVVEVVEEVVVEEEEEEVVIEEVVVVEEVVVEVEVVVEVVVEVIVEVVVVEEEEEVVVEVEEEVEVEEVEVVVEVVVEEEEEEVEVEVEVVEVVVVVEVEVEVEEEEVVEVEEEEVVEEEEEVEVEVEVVVEEVVEVVVVEEEEEVEVVVVVEEEVEEVEEEEVEEVVVEEEVEEVEEEEEEEVVVEVVEEVEVEEEVVVVEVEEVEVEVVVEEVEVVEVVVEVEEEEVVEVEVVEEVVVEEVVVVEVVVVEVVVVVEVEVVVVEVEEEEEEVVVEVVEEVVVEEVEEEEEEEEVVEEVEVEVVEVEIVVEEVEEVVEEVEEEIVVVVIEEEEEVEEEVEEEVVEVVEVVEVVEVEVEVEVVVEVE";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_12_Line_9()
        {
            string a = "cCccCoccocOOCCOccoccoCooCocoOoCcoCoooooOcococccOoocCoccOcoCcoooocCoooocCwcooowcocoocOococoocooOooCCooccooCCocooccoCoococccCccocoOoCcOCocccocOoOooOOooooccOcococcOOooCccooCoccOccoCcoCccOcccOoCCococCooOCoocccocoOocoOCCcoccOcOcccoOooooOOOoOcCcocCoCoOCOOcOcOOocooooocoCccocooocoooocccccooccccCCcoocococCcccCOcccccOoooOoooCcocccooocoCccOCCCccooccOwcCoccCcCcccocooOocCocccoOccocooccOocccooocooccOcccocoocoOOCOocOoococooOoOcocoocOcCcococcocCcoCoCOoOcoOOccoCcOoococoCooocccCooccCCcccCOooocoCOoOCcCccccocwcoCCOOcOoOccccCcocoCCococcCooOCcocccocOcocoocooooCoccccooOccCocoOOocococooOcccCocoOoccoCoocOccOoOOooooooocCoocCCcccococoooocCcoOooooOCcOccCooooOoocccccocoOocoCccCCcwOoOcocoocoOocccoOoCccocoocccccccooowccccOcCCoocooocOooococOOoooccoOwooOCccccoooocCooooooooooCwcooCcccoOcCoooOoOcwOoCoCcCocwoOOCcoocOOcCooocOoOooOoOccOcccocCoOcOcocoococcOoooccccccCoCooCcoooocCccOCccCooCcoOCcocoocOcoocoooOocCcCcoocoCOoOoocooCococoOccCoCoooocOoooOcoooCccocoocococOcOCccccoocccccccCooOoowoOcooOcCCOoCccCocooccoccoCCoccocOcccCo";
            string b = "CCCOOCCOCOCOCOOCCCOOCOCOCOCOCCCOOCOOCOOWCOOOOOOOOOOCCOOCCCCCOCOCOOCOCOOOOOOOOOOOCCOCOOCCCCCOCOOCCCCOCOCCOOOOCCCOCOOCOOOOOOOCCCCOOCOOCOOOOOOCCOOOOCCCCCCCCOCCCCOOOOOCOCOCCOCCCCOCOCCCCCCCOOCCOCCOCCOOOCOOOOCOOOOOOCCOOCCOOCOCCCCOOOOOOOCOCOCCCCCCOOOCCOOCCCCCCOOCOOCCCCCOOCCCOCCCOCOOCOCCOCCOOOOOOOOOCCOOOCCOCOOOOOOOOCCCCOCOOCCOOOCOCCOOOOCOOOCCCWOOOCCOOCCOCCOCCOOCOCCCOCOOOOOCOOOCCCCCOCOCOOCOOWOOCCCOOOCCOOOCCOOCOOOOOOCOCCCOOCCCOOCOCOCOCCCCOCCCCOCCOOOOOCCOCCOOOOCOOCCCOOOCOOOOCCCOCOCCCOCCOOOCCOOCCCOOCCOCOOCC";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_13_Line_0()
        {
            string a = "ERreEerREeerErrrrRRyeReErrerrereEEeRRErRrrereeeeerErereerReRereeeeCrreErREreeerrRrRERreeererererEeEEeerrerrereeRRerreeerrreRererereeSerEeeRereerrReErrrereErrerrrreererrsRRecerEreeRrrreRereerErrRRrrEeEererRrrreRerReRrereererereEeereEereesrERreReeerReErEeeeeRererReereRereerRrrRRerrerreeereEeeereerrEreeERreReRrEErRRerEereeeRreeErReerrEerEeEreerrTeeeEErreRErrerreeeeereeEeerERErRrereerreerRrrreerEreeRrErreeeRReRerrreerrEreerrerEeEeerreeeeEeerRrrerrsrerrereReREerEerrRerRErereRreerRreRReEeeeRerRereeerRerererrerrrreeReeERereeeesrrEerrrreeeeerrrrereeeeeerRrRrreeereRrreeseERrrrerReeeerreeeeereEerErrrRrreeeerRerrrrrErRreREeeerrrrrrrErrreerrRrereerrRrEEErsREeeerReEeErrrrRrRererereeererreereeRreerrerREeEReereerrrrrrereereeeerEeeeerreerSrReererrRereREreereErEReEReeeerrerEeeEeeRreeeRreeeEreeeeEreerrrEeereeerrrrERrRERReeerreEeJEEeSEeeeEeEeeRrRrrreeeRerrreerEreeererEereeeeRRrreReRrEerreEreeeerEErRrRrrrrerrereeEERErerreerrRrrreeeErEeErEreRrErRrErrreeeereeerrrrSeReeeeRerrrrerrEreerEeeeeeeerrreerreRerrREr";
            string b = "ERREREERERRREERREERRERRREEEERRREREEECEREERRRERREEEERRREERRERRRRSERERERERERERRRRRREERREREERRREEERERRRRRRREREEESEREREREEEERRERERRRERRRRREEREREERERREERRERRERREREEEERRTEEEEREEREEEEEEEERERRRRERREERREREERRREREREEREEREEERRRERERERREEREERRERRERERERRRREEERRREERRRRREREREREEEEERRRRRRRREERRERRERRRERERRREEERRRRERRERERRRERRRREREERREEESREEREERRRERREEEERRERERREEREREEREERREEEEEERRRSRERREREEEERERREREEERRERREEEEEEEREEERERRERREREEJEESEEEEEEERRRREEREREEEEEERERRRRRRREEEEREERRREEREEERRREEEEREERRERRERRRSREEERERREERRRRER";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_13_Line_1()
        {
            string a = "rReRRREreEreERRrreeeRrrrErReerreererEreEEseeEeErreEEereeerrerREreeeeerreeerrEEEReErrEeeeeREesrRerereRrreRreRRrreeEeEeERerrreweRrrEREEerRrrreRRrrEREreEerrrerrRerReeeerrErrreREreerrrRrreeereEseErreerrEreererRreereerrreeRrreEreerreRRErRERereEEerReReeEERrEEeeEeEeereeReeeeeReEerEREReseereRereEeeerEreEEereerEeEesrerrRerrererrerrReERrreeereeeeRerrEeeEerreRRrrRErseeErrEeeeerreeRErrRrRerrrrrerRErrerEeeeerrreerrreErrerEeeeeRRererrEReEeeererErErErRerrerErRrrRRrerrErrerrreErerrrreerreERReRerererErreRrererreRrReEERRereeeErEreeREEeeeErReRrreerRrRrreeRrRrEEEEereeerErrrerreErErrRRrreErReReRerrrerEereRreerererReERREeeeeeEeRerRerReeSrreesreeeeREeErresreeReeRrerrrrererrrrrreerrrrrrRREEerrerrErRRRereeerrREEreeEeerrEeeereeerReRerrrEEerrEEReEeerErerRrErSerErRRreERrerEeeerereEreEeerrREEEReereeRErerRrrrReeReEERrrerereereeErEEREeRSreRrRrreerrrReErReErerreerrrRrseererrerererrrreEeeRReRrerreeRerrRRerRPeeRerrreeRrrREereeEErererrRRRererrrerEEerrRrrReerRereeEerrsREEReEerEreEErrrsErreErereeerrrrRrrEeeErReEeReEeeeeEe";
            string b = "RRRREERERREERRERREEEEEEEEEERRREREEERRREEEEEEREESRRRRRRREEERRRREERRERREREEREREEERERRREERRRRESERERRERRRREEEEERREREREEEERREEERREEEEEEREEEREEERERERREEREREEEEEERRREREERRREERRRRRREEREEEERERREREREERRREEREREERREREREEREERERERRRERERERERRRREERRRERERRRERRREERREEEEEREREEREEEERRRREERRRRERRREEEERERERERRRERRREEREEREERERREEEERRRESRESEREESRERRRRRRRERRRREEERERRRRERREEEEEEEEERRRRRREREEREEEERRESRRRRRREREEEEREERREEERRERRRREEERREEEEEERRSRRRERRERREERREERRRREERRRRRRRRRRPRRREEEEEEERRREEERRRRRERREEREEEEEREREEEERREEEREEREE";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_13_Line_2()
        {
            string a = "yllyyyyllyyllyyyyllylyylyyyllllyyyyyyyllllylllylyylyllyylylyllyllllylyylylllyllyyllyyllylllyyyyyyllyyyyllllylyyyllllylyllylyyyllyllyyylylyyllllyllyyyyyllylyllllllllyyyllyllyyylyylyyyyyyyylyyyllyylyylyyllylyllllyyyyllyylyyyyyyyyylyyyyllyylyylllyylylyylyyylllylyllylyyyylyllylylllylllllyylylyylllllyylylyylllylyyyyllyyyyyyylyllyyllllyllyyylyyllllllyyllyylllyylllyllyyyyylyllyllyyyllylyyyyllyylyllyyyyyyyylllyyyyyylyylyylylyyyyyyylllyyyyylylyllllyyyylyyllylyyylyllyyllyyyyyyyyylylllylylllyllylllyllylyllylyllylyllyyllllylllllyyyylllylllyllyllyylllyyyyllyllylylylyylyylyylyyylylllylylyylllllyyyllylylyylylllllyylyllyyylylyyyylyylyllylyyllylyllyyyylyyyyylyyyylclyylylylylyllyyylyyyllllllllylyllyylylylllyylylylylyyylyllyylyyllyyyyyyylllyyyyylllylyyllyylylyylllyyylylyyyllyllyyllylyllyylylylyylylyyyylyllllyyyylylylylllllllllylyllyllylllyyylylyyllylllylyylyylylyyylylyylyyyyllyyllylylyllyylyllylyyyyllyllyllylyyyllllylylllyllllyylllyyyyylylyllyllylylylllyyyllllylylyllllyylyllyyyyylyyyyylyllylyyyyylyylelyy";
            string b = "LLYYYLYYLLYYYLLYLYYLYYYLLLLYYYYYYYLLLLYLLLYLYYLLLYYLYLYLLYLLLLYLYYLYLYLLYYLLYYLLYLLLYYYYYYLLYYYYLLLLYYYYLLLLYLYLLYLYYYLLYLLYYYLYLLLLYLLYYYYYLYLYLLLLLLLLYYYLLYLLYYYYLYYYYYYYLYYYLLYYLYYLYYLYLYLLLLYYYYLLLYYYYYYYYYYYLLYYLYYLLYYLYLYYLYYYLLLYLYLYLYYLYLLYLYLLLYLLLLYYLYLYYLLLLYYLYYYLLLYLYYYLYYYYYYYLYLYYLLLYLLYYYYLLLLLLYYLLYYLLLYYLLLYLYYYYYLYLLYLYYYLLLYYYYLLYYLYLLYYYYYYLLLYYYYYYLYYLYYLYLYYYYYLLYYLYLYLLLLYYYYYLLYLYYYLYLLYLLYYYYYYYYYLYLLLYLYLLLYLLYLLLYLYLYLYLYLYLYLLYLLLLYLLLLLYYYYLLYLLLLLYLYYLLLYYYYLLYLYLYLLYYLYYLYYLYYYLYLLLYLYLYYLLLLLYYYLLYLYLYYLYLLLLYYLYLLYYYLYYYYLYYLLLLYYLYYLLYYYYLYYYYLYYYLLYYLYLYLYLYLYYYLYYYLLLLLLLLYLYLLYLYLYLLYYLYLYLYYYLYYYLYYLLYYYYYYYLLLYYYYYLLYLYYLLYYLYLYYLLLYYYLYLYYYLLYLLYLLYLYLYYLYLLYLYLYYYLYLLLLYYYYLYLYLYLLLLLLLLYLYLYLLYLLLYYYLYLYLLYLLYLYYLYYLYLYYYLYLYYLYYYYLLYYLLYLYLLYYLLLYYYYYYLLYLYLYYLLLYLYLLYLLLYYLLLYYYYYLYLYLLYLYLYLLLLYYYLLLLLYLYLLLLYYLYLLYYYYYLYYYYYLYLYLYYYYYLYYLLYY";
            Assert.IsTrue(Abbreviation.Solve(a, b));
        }

        [TestMethod]
        [Timeout(MaxMs)]
        public void TestCase_13_Line_3()
        {
            string a = "rararaarraraaraArarrrraaaqararraararrrrrrraarrrrarAarraaaarraaryrraaarrraararrardaaarrrRaaarrRraaRarrrrrarraraaaaarrrarrararraarrararrrraraaaaarrarrrrraaarrrrarrrarararraraaaaaarrrararrrraRaraAraaraARARaraarraarararaarrarrArAraAarrrrarrrrRrrraraaraaarrraraaarrrarrrraRarararrraraaraaarraaaaaAaaarrrararraaaaararRaaarraaaRrarraraaaaraaarrrarraarraaraaarrraaaaararrrwraraaaraarraaarrraaararaaarraraaaaarrrrarrrraaaarrarrrrrararararararrArarraaaaraAArrrarrrArrArrAraarRrraraaaAraaarrrarraarnraaaaarraaraaaaraaararaaarrarraarraararraaraAaraaaraaaaaaaaArrrrrarararaaraarRaarrrrraarrraraararaaararaarraAraaaaArrAraarArrararrraarrararrrarRarrrrrrarrrrarraarraarrarrraraaaaararAarararaarraaRararrArarAaraaarrrrraaaaarrrraararraaraaraauaraaaaraaarrrarrrrrraarroaraarrrrarraraRrrraaaaarrraarraarrrraararrrrhraarrarrraaaaarararRrarArrrraraaaarArraarraarraraaaraarrrAaaaraaraaaaraaararaArrrraaarrararrarrraararaarrrrrarArrarrrraaaraarrrraaRarrrrararaaararrrarrararaaarararraarRraaarRrrrrraraarrraraarraraarrRarar";
            string b = "RARARAARRARAAAARRRRRAAAARARRAARARRRRRRRAARRRRARAARRAAAARRAARRRAAARRRAARARRARAAARRRRAAARRRRAARARRRRRARRARAAAAARRRARRARARRAARRARARRRRARAAAAARRARRRRRAAARRRRARRRARARARRARAAAAAARRRARARRRRARARAARAARAARARARAARRAARARARAARARRARARAAARRRRARRRRRRRRARAARAARRRARAAARRRARRRRARARARARRRARAARAAARRAAAAAAAAARRRARARAAAAARARRAARRAAARRARRARAAAARAARRRARRAARRAARAAARRRAAAAARARRRRARAAARAARRAAARRRAARARAAARRARAAAAARRRRARRRRAAAARRARRRRRARARARARARARRARARRAAAARAAARRRARRRARRARRARAARRRRAAAAARAAARRRRRAAAAAAARRAARAAARAARARAAARRARRAARRAARARRAARAAAAAARAAAAAAAAARRRRRAARARAARAARRARRRRRAARRARAARRAAARARAARRAARAAAAARRARAARARARARRRAARRARARRRARRARRRRRRARRRRARRAARRAARRARRRARAAAAARARAARARAAARRAARARARRARARAARAAARRRRRAAAARRRAARARRAAAARAAARAAAARAAARRRARRRRRRAARRARAARRRRARRARARRRRAAAAARRRAARRAARRRAARARRRRRARARRRAAAAARARARRRARARRRRARAAARARAARAARRAAAARAARRRAAAARARAAAARAARARAARRRRAAARRARRRARRRARARAARRRRRARARRARRRAAARAARRRRAAARRRRARARAAARARRRARARRAAARARARRARRRAARRRRRRRARAARRARAARRARAARRRARAR";
            Assert.IsFalse(Abbreviation.Solve(a, b));
        }
    }
}
