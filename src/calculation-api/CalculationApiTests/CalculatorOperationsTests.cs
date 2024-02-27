using System.Collections;
using CalculationApi;

namespace CalculationApiTests;

[TestFixture]
public class CalculatorOperationsTests
{
    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.MultiplicationTestCases))]
    public decimal MultiplicationTest(decimal leftValue, decimal rightValue)
    {
        return Calculator.Operations['*'](leftValue, rightValue);
    }

    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.DivisionTestCases))]
    public decimal DivisionTest(decimal leftValue, decimal rightValue)
    {
        return Calculator.Operations['/'](leftValue, rightValue);
    }

    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.SumTestCases))]
    public decimal SumTest(decimal leftValue, decimal rightValue)
    {
        return Calculator.Operations['+'](leftValue, rightValue);
    }

    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.SubtractionTestCases))]
    public decimal SubtractTest(decimal leftValue, decimal rightValue)
    {
        return Calculator.Operations['-'](leftValue, rightValue);
    }
}

file class DataClass
{
    public static IEnumerable MultiplicationTestCases
    {
        get
        {
            yield return new TestCaseData(457.1723m, 50.2175m).Returns(22958.04997525m);
            yield return new TestCaseData(98.6523m, 65.5716m).Returns(6468.78915468m);
            yield return new TestCaseData(58.8399m, 14.1049m).Returns(829.93090551m);
            yield return new TestCaseData(70.954m, 3.8078m).Returns(270.1786412m);
            yield return new TestCaseData(536.1711m, 19.7721m).Returns(10601.22860631m);
            yield return new TestCaseData(717.9148m, 28.3195m).Returns(20330.9881786m);
            yield return new TestCaseData(1168.6284m, 38.5103m).Returns(45004.23027252m);
            yield return new TestCaseData(15.8339m, 83.1814m).Returns(1317.08596946m);
            yield return new TestCaseData(95.8918m, 18.35m).Returns(1759.61453m);
            yield return new TestCaseData(601.0895m, 23.9481m).Returns(14394.95145495m);
            yield return new TestCaseData(100.5952m, 2.8868m).Returns(290.39822336m);
            yield return new TestCaseData(9.5607m, 2.8101m).Returns(26.86652307m);
            yield return new TestCaseData(212.747m, 109.0637m).Returns(23202.9749839m);
            yield return new TestCaseData(282.2553m, 88.872m).Returns(25084.5930216m);
            yield return new TestCaseData(464.6579m, 72.4188m).Returns(33649.96752852m);
            yield return new TestCaseData(1216.5189m, 3.3618m).Returns(4089.69323802m);
            yield return new TestCaseData(402.3158m, 1.4156m).Returns(569.51824648m);
            yield return new TestCaseData(299.894m, 1.3478m).Returns(404.1971332m);
            yield return new TestCaseData(483.6067m, 74.0226m).Returns(35797.82531142m);
            yield return new TestCaseData(675.9675m, 59.8431m).Returns(40451.99069925m);
            yield return new TestCaseData(698.2529m, 16.449m).Returns(11485.5619521m);
            yield return new TestCaseData(423.3679m, 2.1928m).Returns(928.36113112m);
            yield return new TestCaseData(354.32m, 42.0535m).Returns(14900.39612m);
            yield return new TestCaseData(93.5203m, 5.2586m).Returns(491.78584958m);
            yield return new TestCaseData(581.5367m, 81.0426m).Returns(47129.24616342m);
            yield return new TestCaseData(1140.6344m, 35.9527m).Returns(41008.88639288m);
            yield return new TestCaseData(452.853m, 30.6404m).Returns(13875.5970612m);
            yield return new TestCaseData(414.1593m, 4.7925m).Returns(1984.85844525m);
            yield return new TestCaseData(396.8694m, 12.0699m).Returns(4790.17397106m);
            yield return new TestCaseData(91.3219m, 64.2097m).Returns(5863.75180243m);
            yield return new TestCaseData(96.4764m, 44.1421m).Returns(4258.67089644m);
            yield return new TestCaseData(231.8716m, 25.7056m).Returns(5960.39860096m);
        }
    }

    public static IEnumerable DivisionTestCases
    {
        get
        {
            yield return new TestCaseData(111.1649m, 90.3605m).Returns(1.2302377698219908035037433392m);
            yield return new TestCaseData(82.9969m, 70.9206m).Returns(1.1702791572547327574780811217m);
            yield return new TestCaseData(758.173m, 29.8408m).Returns(25.407261199431650625988579395m);
            yield return new TestCaseData(373.8932m, 17.9705m).Returns(20.805943073370245680420689463m);
            yield return new TestCaseData(353.5703m, 83.8257m).Returns(4.2179224271315360325055442424m);
            yield return new TestCaseData(1.4998m, 41.4169m).Returns(0.0362122708363011234544352668m);
            yield return new TestCaseData(103.9324m, 87.5974m).Returns(1.1864781374789662706883994274m);
            yield return new TestCaseData(823.1398m, 7.8175m).Returns(105.29450591621362328110009594m);
            yield return new TestCaseData(87.2861m, 72.3439m).Returns(1.2065440209886389868392497502m);
            yield return new TestCaseData(902.4114m, 3.06m).Returns(294.90568627450980392156862745m);
            yield return new TestCaseData(232.8392m, 19.6839m).Returns(11.828916017659102108830059084m);
            yield return new TestCaseData(7.1657m, 3.2238m).Returns(2.2227495502202369874061666356m);
            yield return new TestCaseData(100.9797m, 4.8494m).Returns(20.823132758691796923330721326m);
            yield return new TestCaseData(98.7703m, 30.7026m).Returns(3.2170011660250271963937907539m);
            yield return new TestCaseData(404.397m, 15.4055m).Returns(26.250170393690565057933854792m);
            yield return new TestCaseData(424.6391m, 21.9339m).Returns(19.359945107801166231267581233m);
            yield return new TestCaseData(322.4932m, 38.4113m).Returns(8.395789780611434655947598753m);
            yield return new TestCaseData(134.3134m, 13.8321m).Returns(9.710268144388776830705388191m);
            yield return new TestCaseData(373.9865m, 9.4081m).Returns(39.751543882399209192079165825m);
            yield return new TestCaseData(1388.0541m, 47.9179m).Returns(28.967339971075527099476396086m);
            yield return new TestCaseData(414.6105m, 11.8781m).Returns(34.905456259839536626228100454m);
            yield return new TestCaseData(55.8613m, 79.7409m).Returns(0.7005351080812983048849461192m);
            yield return new TestCaseData(754.9966m, 10.0114m).Returns(75.413688395229438440178196856m);
            yield return new TestCaseData(8.2791m, 5.2248m).Returns(1.5845774000918695452457510335m);
            yield return new TestCaseData(47.6915m, 7.8584m).Returns(6.0688562557263565102310902983m);
            yield return new TestCaseData(19.6774m, 15.7835m).Returns(1.2467070041499033801121424272m);
            yield return new TestCaseData(1853.1629m, 29.3756m).Returns(63.085108048856874412777951769m);
            yield return new TestCaseData(97.7419m, 33.8336m).Returns(2.8889003830511680696112739998m);
            yield return new TestCaseData(1405.7032m, 108.556m).Returns(12.949106451969490401267548546m);
            yield return new TestCaseData(463.7298m, 9.6064m).Returns(48.273005496335776149233844104m);
            yield return new TestCaseData(35.8312m, 9.0903m).Returns(3.9416960936382737643422109281m);
            yield return new TestCaseData(198.271m, 2.0273m).Returns(97.80052286292112662161495585m);
        }
    }

    public static IEnumerable SumTestCases
    {
        get
        {
            yield return new TestCaseData(541.8341m, 358.7187m).Returns(900.5528m);
            yield return new TestCaseData(73.263m, 409.498m).Returns(482.761m);
            yield return new TestCaseData(100.7241m, 537.9488m).Returns(638.6729m);
            yield return new TestCaseData(213.7193m, 238.6526m).Returns(452.3719m);
            yield return new TestCaseData(199.1388m, 108.7479m).Returns(307.8867m);
            yield return new TestCaseData(202.8344m, 610.0565m).Returns(812.8909m);
            yield return new TestCaseData(240.158m, 47.5081m).Returns(287.6661m);
            yield return new TestCaseData(188.4358m, 410.3851m).Returns(598.8209m);
            yield return new TestCaseData(665.2434m, 391.8848m).Returns(1057.1282m);
            yield return new TestCaseData(23.7882m, 312.2917m).Returns(336.0799m);
            yield return new TestCaseData(788.0412m, 32.8092m).Returns(820.8504m);
            yield return new TestCaseData(235.0564m, 64.5143m).Returns(299.5707m);
            yield return new TestCaseData(357.4917m, 104.3253m).Returns(461.817m);
            yield return new TestCaseData(87.4352m, 516.679m).Returns(604.1142m);
            yield return new TestCaseData(6.0777m, 384.1093m).Returns(390.187m);
            yield return new TestCaseData(267.6927m, 112.3158m).Returns(380.0085m);
            yield return new TestCaseData(44.2172m, 835.1356m).Returns(879.3528m);
            yield return new TestCaseData(434.1881m, 54.8952m).Returns(489.0833m);
            yield return new TestCaseData(8.6898m, 368.7849m).Returns(377.4747m);
            yield return new TestCaseData(69.9627m, 46.203m).Returns(116.1657m);
            yield return new TestCaseData(496.5462m, 365.2007m).Returns(861.7469m);
            yield return new TestCaseData(140.5445m, 372.7894m).Returns(513.3339m);
            yield return new TestCaseData(135.0387m, 15.6842m).Returns(150.7229m);
            yield return new TestCaseData(93.8262m, 36.8348m).Returns(130.661m);
            yield return new TestCaseData(272.6371m, 22.6227m).Returns(295.2598m);
            yield return new TestCaseData(238.9135m, 263.0049m).Returns(501.9184m);
            yield return new TestCaseData(176.0007m, 63.8612m).Returns(239.8619m);
            yield return new TestCaseData(545.3528m, 490.6253m).Returns(1035.9781m);
            yield return new TestCaseData(211.9789m, 94.8934m).Returns(306.8723m);
            yield return new TestCaseData(113.1204m, 147.8072m).Returns(260.9276m);
            yield return new TestCaseData(48.4096m, 284.4996m).Returns(332.9092m);
            yield return new TestCaseData(235.1822m, 23.5661m).Returns(258.7483m);
        }
    }

    public static IEnumerable SubtractionTestCases
    {
        get
        {
            yield return new TestCaseData(1330.3484m, 36.0291m).Returns(1294.3193m);
            yield return new TestCaseData(88.8378m, 7.8079m).Returns(81.0299m);
            yield return new TestCaseData(441.1783m, 0.7306m).Returns(440.4477m);
            yield return new TestCaseData(600.5544m, 1.8795m).Returns(598.6749m);
            yield return new TestCaseData(149.7809m, 41.2826m).Returns(108.4983m);
            yield return new TestCaseData(1032.7377m, 22.3737m).Returns(1010.364m);
            yield return new TestCaseData(21.4448m, 10.9171m).Returns(10.5277m);
            yield return new TestCaseData(448.7459m, 32.0765m).Returns(416.6694m);
            yield return new TestCaseData(696.7165m, 15.1556m).Returns(681.5609m);
            yield return new TestCaseData(1286.638m, 117.1844m).Returns(1169.4536m);
            yield return new TestCaseData(408.892m, 41.74m).Returns(367.152m);
            yield return new TestCaseData(82.173m, 1.0954m).Returns(81.0776m);
            yield return new TestCaseData(74.0146m, 91.0736m).Returns(-17.059m);
            yield return new TestCaseData(314.953m, 147.4901m).Returns(167.4629m);
            yield return new TestCaseData(125.8572m, 46.6078m).Returns(79.2494m);
            yield return new TestCaseData(59.6108m, 4.6387m).Returns(54.9721m);
            yield return new TestCaseData(918.3565m, 3.8212m).Returns(914.5353m);
            yield return new TestCaseData(1157.6381m, 21.3094m).Returns(1136.3287m);
            yield return new TestCaseData(1457.9329m, 40.0348m).Returns(1417.8981m);
            yield return new TestCaseData(511.8125m, 125.4218m).Returns(386.3907m);
            yield return new TestCaseData(786.5492m, 51.3507m).Returns(735.1985m);
            yield return new TestCaseData(1153.9492m, 71.6423m).Returns(1082.3069m);
            yield return new TestCaseData(842.6757m, 23.8732m).Returns(818.8025m);
            yield return new TestCaseData(1687.8037m, 4.6759m).Returns(1683.1278m);
            yield return new TestCaseData(126.3019m, 70.4479m).Returns(55.854m);
            yield return new TestCaseData(626.1138m, 82.9319m).Returns(543.1819m);
            yield return new TestCaseData(808.051m, 37.9321m).Returns(770.1189m);
            yield return new TestCaseData(28.5801m, 81.6246m).Returns(-53.0445m);
            yield return new TestCaseData(386.786m, 4.3076m).Returns(382.4784m);
            yield return new TestCaseData(37.3574m, 7.0141m).Returns(30.3433m);
            yield return new TestCaseData(654.425m, 110.2023m).Returns(544.2227m);
            yield return new TestCaseData(23.0538m, 12.6406m).Returns(10.4132m);
        }
    }
}
