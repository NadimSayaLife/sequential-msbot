// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Schema;

namespace Microsoft.BotBuilderSamples
{
    /// <summary>
    /// This is our application state. Just a regular serializable .NET class.
    /// </summary>
    public class UserProfile
    {
        public string Email { get; set; } = "Enter your registered email with stop-truma";

        public Question1 question1 { get; set; } = new Question1();
        public Question2 question2 { get; set; } = new Question2();
        public Question3 question3 { get; set; } = new Question3();
        public Question4 question4 { get; set; } = new Question4();
        public Question5 question5 { get; set; } = new Question5();
        public Question6 question6 { get; set; } = new Question6();
        public Question7 question7 { get; set; } = new Question7();
        public Question8 question8 { get; set; } = new Question8();
        public Question9 question9 { get; set; } = new Question9();
        public Question10 question10 { get; set; } = new Question10();
        public Question11 question11 { get; set; } = new Question11();
        public Question12 question12 { get; set; } = new Question12();
        public Question13 question13 { get; set; } = new Question13();
        public Question14 question14 { get; set; } = new Question14();
        public Question15 question15 { get; set; } = new Question15();
        public Question16 question16 { get; set; } = new Question16();
        public Question17 question17 { get; set; } = new Question17();
        public Question18 question18 { get; set; } = new Question18();
        public Question19 question19 { get; set; } = new Question19();
        public Question20 question20 { get; set; } = new Question20();
        public Question21 question21 { get; set; } = new Question21();
        public Question22 question22 { get; set; } = new Question22();
        public Question23 question23 { get; set; } = new Question23();
        public Question24 question24 { get; set; } = new Question24();
        public Question25 question25 { get; set; } = new Question25();
        public Question26 question26 { get; set; } = new Question26();
        public Question27 question27 { get; set; } = new Question27();
        public Question28 question28 { get; set; } = new Question28();
        public Question29 question29 { get; set; } = new Question29();
        public Question30 question30 { get; set; } = new Question30();
        public Question31 question31 { get; set; } = new Question31();
        public Question32 question32 { get; set; } = new Question32();
        public Question33 question33 { get; set; } = new Question33();
    }
    public class Question1
    {
        public string Question { get; set; } = "Jeste li?";
        public string Answer { get; set; }
    }
    public class Question2
    {
        public string Question { get; set; }="Dob";
        public string Answer { get; set; }
    }
    public class Question3
    {
        public string Question { get; set; }="Završena razina obrazovanja";
        public string Answer { get; set; }
    }
    public class Question4
    {
        public string Question { get; set; } = "Trenutno stanje zaposlenja";
        public string Answer { get; set; }
    }
    public class Question5
    {
        public string Question { get; set; } = "S kim živite?";
        public string Answer { get; set; }
    }
    public class Question6
    {
        public string Question { get; set; } = "Jeste li bili u dugoročnoj vezi/ braku prije rata?";
        public string Answer { get; set; }
    }
    public class Question7
    {
        public string Question { get; set; } = "Trenutno bračno stanje";
        public string Answer { get; set; }
    }
    public class Question8
    {
        public string Question { get; set; } = "Bavite li se trenutno nekom fizičkom aktivnošću?";
        public string Answer { get; set; }
    }
    public class Question9
    {
        public string Question { get; set; } = "Koje sportove volite igrati?";
        public string Answer { get; set; }
    }
    public class Question10
    {
        public string Question { get; set; } = "Kako opisujete svoj odnos sa svojim starim ratnim prijateljima danas";
        public string Answer { get; set; }
    }
    public class Question11
    {
        public string Question { get; set; } = "Jeste li ostali prijatelji sa suborcima";
        public string Answer { get; set; }
    }
    public class Question12
    {
        public string Question { get; set; } = "Jeste li pripadnik neke braniteljske udruge?";
        public string Answer { get; set; }
    }
    public class Question13
    {
        public string Question { get; set; } = "Jeste li bili na bilo kakvom zdravstvenom liječenju prije rata?";
        public string Answer { get; set; }
    }
    public class Question14
    {
        public string Question { get; set; } = "Jeste li bili na bilo kakvom liječenju tijekom rata (TR) ili nakon rata (NR)";
        public string Answer { get; set; }
    }
    public class Question15
    {
        public string Question { get; set; } = "Jeste li imali ikakvu traumatsku ozljedu mozga (TBI - Traumatic Brain Injury) tijekom rata?";
        public string Answer { get; set; }
    }
    public class Question16
    {
        public string Question { get; set; } = "Imate li trenutno tjelesni invaliditet koji je posljedica ratnih ozljeda?";
        public string Answer { get; set; }
    }
    public class Question17
    {
        public string Question { get; set; } = "Imate li ponavljajuće uznemirujuće misli, flashbackove ili sjećanja o prošlim uznemirujućim iskustvima?";
        public string Answer { get; set; }
    }
    public class Question18
    {
        public string Question { get; set; } = "Tijekom prošlog mjeseca jeste li imali iznenadne osjećaje, kao da ponovno proživljavate sjećanja?";
        public string Answer { get; set; }
    }
    public class Question19
    {
        public string Question { get; set; } = "Osjećate li fizičke reakcije kada Vas nešto podsjeti na uznemirujuće iskustvo, primjerice ubrzane otkucaje srca, nedostatak zraka, znojenje, bolove, nelagodu?";
        public string Answer { get; set; }
    }
    public class Question20
    {
        public string Question { get; set; }="Je li tijekom prošlog mjeseca Vaša zabrinutost negativno utjecala na Vašu sposobnost rada na poslu, odnos s prijateljima, obitelji ili u drugim područjima koja su Vam važna?";
        public string Answer { get; set; }
    }
    public class Question21
    {
        public string Question { get; set; } = "Jesu li patili Vaši odnosi s voljenima kao rezultat prošlih uznemirujućih iskustava?";
        public string Answer { get; set; }
    }
    public class Question22
    {
        public string Question { get; set; } = "Tijekom prošlog mjeseca, jeste li razmišljali o namjernom ozljeđivanju ili ste namjerno ozlijedili sebe?";
        public string Answer { get; set; }
    }
    public class Question23
    {
        public string Question { get; set; } = "Tijekom prošlog mjeseca, jeste li imali jaka negativna uvjerenja o sebi, drugim ljudima, ili svijetu, na primjer imali ste misli poput, ja sam loš, nešto ozbiljno nije u redu sa mnom, ne može se vjerovati nikome, svijet je opasan?";
        public string Answer { get; set; }
    }
    public class Question24
    {
        public string Question { get; set; } = "Tijekom prošlog mjeseca, koliko često ste krivili sebe ili nekog drugoga za uznemirujuće osjećaje?";
        public string Answer { get; set; }
    }
    public class Question25
    {
        public string Question { get; set; } = "Tijekom prošlog mjeseca, koliko često ste imali jake negativne osjećaje poput straha, užasa, ljutnje, krivnje ili srama? ";
        public string Answer { get; set; }
    }
    public class Question26
    {
        public string Question { get; set; } = "Tijekom prošlog mjeseca, jeste li doživjeli gubitak interesa za aktivnosti u kojima ste nekad uživali?";
        public string Answer { get; set; }
    }
    public class Question27
    {
        public string Question { get; set; } = "Tijekom prošlog mjeseca, jeste li se osjećali daleko ili odsječeno od rodbine, partnera, prijatelja ili bliskih ljudi?";
        public string Answer { get; set; }
    }
    public class Question28
    {
        public string Question { get; set; } = "Tijekom prošlog mjeseca, jeste li doživjeli osjećaj da ste sami, izolirani i da nemate društveni kontakt?";
        public string Answer { get; set; }
    }
    public class Question29
    {
        public string Question { get; set; } = "Tijekom prošlog mjeseca, jeste li doživjeli nedostatak pozitivnih osjećaja, na primjer nemogućnost osjećanja sreće ili osjećaja ljubavi prema bliskim ljudima?";
        public string Answer { get; set; }
    }
    public class Question30
    {
        public string Question { get; set; } = "Tijekom prošlog mjeseca, jeste li preuzimali previše rizika ili činili stvari koje bi vam mogle nanijeti štetu?";
        public string Answer { get; set; }
    }
    public class Question31
    {
        public string Question { get; set; } = "Jeste li osjetili jake emocije ili emocionalne reakcije povezane s nekim od ovih okidača (jer mogu podsjetiti na vlastita iskustva tijekom sudjelovanja u ratu):";
        public string Answer { get; set; }
    }
    public class Question32
    {
        public string Question { get; set; } = "Imate li djece?";
        public string Answer { get; set; }
    }
    public class Question33
    {
        public string Question { get; set; } = "Imate li kućne ljubimce?";
        public string Answer { get; set; }
    }
}
