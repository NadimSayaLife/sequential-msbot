// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Schema;
using MindFull.Model.DTOs;
using MindFull.Repository.Account;

namespace Microsoft.BotBuilderSamples
{
    public class UserProfileDialog : ComponentDialog
    {
        private readonly IStatePropertyAccessor<ChatbotQueAns> _userProfileAccessor;
        private readonly IAccountRepository _iAccountRepository;
        public UserProfileDialog(UserState userState, IAccountRepository iAccountRepository)
            : base(nameof(UserProfileDialog))
        {
            _userProfileAccessor = userState.CreateProperty<ChatbotQueAns>("ChatbotQueAns");
            _iAccountRepository = iAccountRepository;

            // This array defines how the Waterfall will execute.
            var waterfallSteps = new WaterfallStep[]
            {
                EmailAsync,
                Question1Async,
                Question2Async,
                Question3Async,
                Question4Async,
                Question5Async,
                Question6Async,
                Question7Async,
                Question8Async,
                Question9Async,
                Question10Async,
                Question11Async,
                Question12Async,
                Question13Async,
                Question14Async,
                Question15Async,
                Question16Async,
                Question17Async,
                Question18Async,
                Question19Async,
                Question20Async,
                Question21Async,
                Question22Async,
                Question23Async,
                Question24Async,
                Question25Async,
                Question26Async,
                Question27Async,
                Question28Async,
                Question29Async,
                Question30Async,
                Question31Async,
                Question32Async,
                Question33Async,
                ConfirmStepAsync,
                SummaryStepAsync,
            };

            // Add named dialogs to the DialogSet. These names are saved in the dialog state.
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            //AddDialog(new NumberPrompt<int>(nameof(NumberPrompt<int>), AgePromptValidatorAsync));
            AddDialog(new NumberPrompt<int>(nameof(NumberPrompt<int>)));
            AddDialog(new ChoicePrompt(nameof(ChoicePrompt)));
            AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt)));
            //AddDialog(new AttachmentPrompt(nameof(AttachmentPrompt), PicturePromptValidatorAsync));
            AddDialog(new AttachmentPrompt(nameof(AttachmentPrompt)));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }
        ChatbotQueAns chatBotQueAns = new ChatbotQueAns();
        private async Task<DialogTurnResult> EmailAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = MessageFactory.Text(chatBotQueAns.Email) }, cancellationToken);
        
        }
        private async Task<DialogTurnResult> Question1Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["email"] = (string)stepContext.Result;
            Task<bool> response = _iAccountRepository.CheckEmailAlreadyExists((string)stepContext.Result);
            if (response.Result.ToString().ToLower() == "true")
            {
                return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question1.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Muškarac", "Žena", "Drugo" }),
                }, cancellationToken);
            }
            else
            {
                 await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = MessageFactory.Text("Email not found, Please try again with registered email.") }, cancellationToken);
                return await stepContext.CancelAllDialogsAsync(cancellationToken: cancellationToken);
            }
        }
        private async Task<DialogTurnResult> Question2Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer1"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question2.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "ispod 40", "40-50", "50-60", "+60" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question3Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer2"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question3.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Osnovna škola", "Srednja škola", "Viša škola ili fakultet", "Program obrazovanja odraslih" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question4Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer3"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question4.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Zaposlen", "Civilni posao", "Ruralni sektor", "Neruralni sektor", "Posao povezan s vojskom", "Posao u zaštitarskoj službi", "Neformalni posao", "Nezaposlen", "invalidska mirovina", "braniteljska mirovina" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question5Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer4"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question5.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Partnericom", "Suprugom", "Partnericom/suprugom i djecom", "Mojom djecom", "Mojim roditeljima", "Rodbinom", "Prijateljem/prijateljima", "Sam", "Drugo" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question6Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer5"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question6.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Da", "Prije rata", "Tijekom rata", "Nakon rata", "Trenutno sam u vezi/braku", "Ne" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question7Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer6"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question7.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Oženjen/živim s partnericom", "Rastavljen/razveden", "Samac", "Udovac" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question8Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer7"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question8.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Da", "Ponekad", "Nikad"}),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question9Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer8"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question9.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Nogomet", "Rukomet", "Trčanje", "Tenis", "Dizanje utega", "Boks", "Plivanje", "Bejzbol", "Ragbi", "Košarka", "Hokej", "Odbojka", "Drugo", "Ništa" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question10Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer9"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question10.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Dobar", "Umjeren", "Ravnodušan", "Loš"}),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question11Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer10"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question11.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Da", "Ne"}),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question12Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer11"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question12.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Da", "Nisam trenutno, ali sam bio u prošlosti", "Ne" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question13Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer12"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question13.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Ne, nikad", "Srčanih problema", "Krvnog tlaka", "Problema s jetrom", "Problema probavnog sustava", "Plućnih/respiratornih problema", "Problema s udovima", "Problema sa sluhom", "Psihijatrijsko savjetovanje/procjena", "Elektrokonvulzivna terapija", "Terapija lijekovima", "Rehabilitacija" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question14Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer13"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question14.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Ne, nikad", "Bolovi u leđima", "Srčanih problema", "Krvnog tlaka", "Problema s jetrom", "Problema probavnog sustava", "Plućnih/respiratornih problema", "Problema s udovima", "Zlouporaba supstanci/ovisnost" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question15Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer14"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question15.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Ne, nikad", "Da, ali trenutno nemam posljedica", "Duži gubitak svijesti", "Kratki gubitak svijesti", "Gubitak pamćenja događaja netom prije ili nakon ozlijede", "Promjenu u mentalnom stanju nakon ozljede", "Problemi s vidom", "Napadaje", "Poteškoće s govorom", "Poteškoće s ravnotežom" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question16Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer15"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question16.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Da", "Ne" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question17Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer16"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question17.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question18Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer17"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question18.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question19Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer18"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question19.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question20Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer19"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question20.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question21Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer20"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question21.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Da", "Mnogo", "Umjereno", "U manjem stupnju", "Ne" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question22Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer21"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question22.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question23Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer22"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question23.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question24Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer23"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question24.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question25Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer24"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question25.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question26Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer25"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question26.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question27Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer26"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question27.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question28Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer27"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question28.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question29Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer28"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question29.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question30Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer29"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question30.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question31Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer30"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question31.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Uopće ne", "Samo povremeno", "Često", "Većinu vremena", "Cijelo vrijeme" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question32Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer31"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question32.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Innò", "1", "2", "3", "Più di 3" }),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> Question33Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer32"] = ((FoundChoice)stepContext.Result).Value;
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(chatBotQueAns.question33.Question),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Innò", "Cani/cani", "Gattu / gatti", "Altru"}),
                }, cancellationToken);
        }
        private async Task<DialogTurnResult> ConfirmStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["answer33"] = ((FoundChoice)stepContext.Result).Value; ;

            // WaterfallStep always finishes with the end of the Waterfall or with another dialog; here it is a Prompt Dialog.
            return await stepContext.PromptAsync(nameof(ConfirmPrompt), new PromptOptions { Prompt = MessageFactory.Text("Assasment-1 Questions are completed, Are you sure you want to save?") }, cancellationToken);
        }
        private async Task<DialogTurnResult> SummaryStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            if ((bool)stepContext.Result)
            {
                // Get the current profile object from user state.
                var chatBotQueAns = await _userProfileAccessor.GetAsync(stepContext.Context, () => new ChatbotQueAns(), cancellationToken);

                chatBotQueAns.Email = (string)stepContext.Values["email"];
                chatBotQueAns.question1.Answer = (string)stepContext.Values["answer1"];
                chatBotQueAns.question2.Answer = (string)stepContext.Values["answer2"];
                chatBotQueAns.question3.Answer = (string)stepContext.Values["answer3"];
                chatBotQueAns.question4.Answer = (string)stepContext.Values["answer4"];
                chatBotQueAns.question5.Answer = (string)stepContext.Values["answer5"];
                chatBotQueAns.question6.Answer = (string)stepContext.Values["answer6"];
                chatBotQueAns.question7.Answer = (string)stepContext.Values["answer7"];
                chatBotQueAns.question8.Answer = (string)stepContext.Values["answer8"];
                chatBotQueAns.question9.Answer = (string)stepContext.Values["answer9"];
                chatBotQueAns.question10.Answer = (string)stepContext.Values["answer10"];
                chatBotQueAns.question11.Answer = (string)stepContext.Values["answer11"];
                chatBotQueAns.question12.Answer = (string)stepContext.Values["answer12"];
                chatBotQueAns.question13.Answer = (string)stepContext.Values["answer13"];
                chatBotQueAns.question14.Answer = (string)stepContext.Values["answer14"];
                chatBotQueAns.question15.Answer = (string)stepContext.Values["answer15"];
                chatBotQueAns.question16.Answer = (string)stepContext.Values["answer16"];
                chatBotQueAns.question17.Answer = (string)stepContext.Values["answer17"];
                chatBotQueAns.question18.Answer = (string)stepContext.Values["answer18"];
                chatBotQueAns.question19.Answer = (string)stepContext.Values["answer19"];
                chatBotQueAns.question20.Answer = (string)stepContext.Values["answer20"];
                chatBotQueAns.question21.Answer = (string)stepContext.Values["answer21"];
                chatBotQueAns.question22.Answer = (string)stepContext.Values["answer22"];
                chatBotQueAns.question23.Answer = (string)stepContext.Values["answer23"];
                chatBotQueAns.question24.Answer = (string)stepContext.Values["answer24"];
                chatBotQueAns.question25.Answer = (string)stepContext.Values["answer25"];
                chatBotQueAns.question26.Answer = (string)stepContext.Values["answer26"];
                chatBotQueAns.question27.Answer = (string)stepContext.Values["answer27"];
                chatBotQueAns.question28.Answer = (string)stepContext.Values["answer28"];
                chatBotQueAns.question29.Answer = (string)stepContext.Values["answer29"];
                chatBotQueAns.question30.Answer = (string)stepContext.Values["answer30"];
                chatBotQueAns.question31.Answer = (string)stepContext.Values["answer31"];
                chatBotQueAns.question32.Answer = (string)stepContext.Values["answer32"];
                chatBotQueAns.question33.Answer = (string)stepContext.Values["answer33"];

                //var msg = $"I have your mode of transport as {userProfile.Transport} and your name as {userProfile.Name} and your dob as {userProfile.question1.Answer}";
                

                var response =_iAccountRepository.MSChatbotAsync(chatBotQueAns);
                if (response.Result.StatusCode == 1)
                {
                    var msg = $"Thanks, We are glad to help you with stop-truma programs. You can login with the portal.";

                    //if (userProfile.Age != -1)
                    //{
                    //    msg += $" and your age as {userProfile.Age}";
                    //}

                    //msg += ".";

                    await stepContext.Context.SendActivityAsync(MessageFactory.Text(msg), cancellationToken);
                }
                else
                {
                    await stepContext.Context.SendActivityAsync(MessageFactory.Text(response.Result.Message), cancellationToken);
                }
            }
            else
            {
                await stepContext.Context.SendActivityAsync(MessageFactory.Text("Thanks. Your profile will not be kept."), cancellationToken);
            }

            // WaterfallStep always finishes with the end of the Waterfall or with another dialog; here it is the end.
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    }
}
