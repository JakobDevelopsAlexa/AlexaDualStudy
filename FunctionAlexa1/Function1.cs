using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
namespace FunctionApp
{
    public static class AddFunction
    {
        [FunctionName("FunctionAlexa1")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            // Simple Function
            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();
            log.Info($"Content={data}");
            if (data.request.type == "LaunchRequest")
            {
                // default launch request, let's just let them know what you can do
                log.Info($"Default LaunchRequest made");
                return req.CreateResponse(HttpStatusCode.OK, new
                {
                    version = "1.0",
                    sessionAttributes = new { },
                    response = new
                    {
                        outputSpeech = new
                        {
                            type = "PlainText",
                            text = "Hallo, herzlich Willkommen bei H P E. Wie kann ich dir helfen?"
                        },
                        shouldEndSession = false
                    }


                });

             }


            else if (data.request.type == "IntentRequest")
            {
                // Set name to query string or body data
                string intentName = data.request.intent.name;
                log.Info($"intentName={intentName}");
                switch (intentName)
                {
                    case "GetInfoIntent":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Dein Studium ist unterteilt in Theorie- und Praxisphasen. Die Theoriephase verbringst du an der dualen Hochschule. Die Praxisphase bei uns im Unternehmen. M�chtest du sonst noch etwas wissen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Das duale Studium besteht aus zwei Teilen. Praxis und Theorie."
                                },
                                shouldEndSession = false
                            }
                        });

                

                  

                    case "GetBlockTheorie":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Okay. Frag mich doch, welche Studieng�nge es gibt, wo du die Theoriephase verbringst, wie lange das Studium dauert oder ob du einen Master machen kannst."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"M�gliche Fragen zur Theorie lauten:"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetBlockPraxis":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Okay. Du kannst mich fragen bei welchen Unternehmen du Praxiseins�tze machen kannst, ob es Geld gibt, was bei H P E so besonders ist, wie du dich bewirbst oder ob du ins Ausland kannst. "
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"M�gliche Fragen zur Praxis lauten:"
                                },
                                shouldEndSession = false
                            }
                        });


                    case "AMAZON.StopIntent":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Bis bald mein junger Padawan."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Auf Wiedersehen."
                                },
                                shouldEndSession = true
                            }
                        });

                    case "GetUnternehmen":

                         return req.CreateResponse(HttpStatusCode.OK, new
                         {
                             version = "1.0",
                             sessionAttributes = new { },
                             response = new
                             {
                                 outputSpeech = new
                                 {
                                     type = "PlainText",
                                     text = $"Deine Praxisphasen kannst du bei H P E oder einem der kooperierenden Partnerunternehmen wie D X C, H P Inc, Aruba Networks, Mikro Fokus oder auch San Data machen. Wenn du mehr �ber ein Unternehmen erfahren m�chtest, sage: was passiert bei Punkt punkt punkt?"
                                 },
                                 card = new
                                 {
                                     type = "Simple",
                                     title = "HPE Duales Studium - App Edition",
                                     content = $"Bei HPE und seinen Partnern kannst du Praxiseins�tze machen."
                                 },
                                 shouldEndSession = false
                             }
                         });

                    case "GetHP":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"H P Inc. ist einer der weltgr��ten P C und Druckerhersteller. Hast du sonst noch Fragen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was passiert bei HP?"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetHPE":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"H P E ist einer der weltgr��ten Hersteller f�r Serverhardware. Diese wird vor allem im gesch�ftlichen Rahmen von Gro�kunden eingesetzt. Willst du noch etwas wissen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was passiert bei HPE?"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetDXC":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"D X C Technology ist ein Ei Tii Beratungsunternehmen und hilft dem Kunden dabei, seine Ziele mit Ei Tii zu erreichen. Kann ich dir sonst noch helfen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was passiert bei DXC?"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetMicroFocus":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Micro Focus ist einer der gr��ten Software Hersteller der Welt. Hier wird Software hergestellt, welche das t�gliche Gesch�ft von Unternehmen unterst�tzt. Fragst du dich sonst noch etwas?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was passiert bei MicroFocus?"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetSanData":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"SanData ist ein Ei Tii Beratungsunternehmen und unterst�tzt Unternehmen bei der Planung, Umsetzung und Wartung ihrer Ei Tii Infrastruktur. Willst du noch mehr wissen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was passiert bei SanData?"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetAruba":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Aruba Networks sorgt zum Beispiel daf�r, dass du bei Starbucks W-Lan hast. Alles rund um Netzwerktechnik. Hast du sonst noch eine Frage?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was passiert bei Aruba Networks?"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetHelpIntent":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Sehr gut. Das DualStudy Universum ist riesig. Dein Studium besteht aus Theorie und Praxisteilen. M�chtest du zuerst etwas �ber die Theorie oder die Praxis erfahren?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Hier deine M�glichekiten."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetFragen":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Du kannst mich zum Beispiel fragen, welche studieng�nge es gibt, bei welchen unternehmen du praxisphasen machen kannst, wie schwer die klausuren sind oder welche vorkenntnisse man f�r das studium braucht."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Frage mich, welche Studieng�nge es gibt oder wie du dich bewerben kannst"
                                },
                                shouldEndSession = false
                            }
                        });


                    case "GetTheorie":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Du wirst die Theoriephase an der d h b w verbringen, der dualen hochschule baden w�rttemberg. Hast du sonst noch Fragen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"An der DHBW."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetStudiumDauer":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Das Studium dauert 3 Jahre. Alle drei Monate wechseln sich Theorie und Praxisphasen ab. Kann ich dir sonst noch weiterhelfen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Das Studium dauert 3 Jahre."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetEierpfannkuchen":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Ganz einfach, keines von beidem. Es hei�t n�mlich Eierpfannkuchen."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Eierpfannkuchen."
                                },
                                shouldEndSession = true
                            }
                        });

                    case "GetKohle":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Im ersten Studienjahr verdienst du 925 Euro pro Monat. Du wirst fl�ssiger sein als ein Glas Wasser. Willst du noch etwas wissen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Klar bekommst du gr�ne Scheine."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetStudiengang":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Es gibt Informatik und Wirtschaftsinformatik. Bei Wirtschaftsinformatik kannst du w�hlen zwischen: IMBIT, International Management for business and Ei Tii. S C, Sales and Consulting. A M, Application Management. S E, Software Engineering und D S, Data Science. Wenn du fragen zu einem Studiengang hast, sage: Was ist PUNKT PUNKT PUNKT? "
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Wirtschaftsinformatik und Informatik."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetIMBIT":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"International Management for business and Ei Tii legt den Grundstein f�r deine Karriere in einem Weltkonzern und konzentriert sich dabei auf Kundenprojekte und die enge Zusammenarbeit internationaler Bereiche."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was ist IMBIT?"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetSC":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Der Studiengang Sales and Consulting ist eine Kombination aus Betriebswirtschaft und Informationstechnik mit Schwerpunkten auf Vertrieb und Projektmanagement. Damit steht dir die Welt offen."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was ist SC?"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetAM":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Schwerpunkte des Dualen Studiums von Application Management sind Betriebswirtschaftslehre, Kosten- und Leistungsrechnung, Marketing, Volkswirtschaftslehre, Recht, Ei Tii-Management, Datenbank-Technologien und Software-Entwicklung."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was ist AM?"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetInformatik":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Schwerpunkte beim Informatik Studium sind modernste Software-Entwicklungsmethoden und Programmiersprachen, Software Engineering, Internet-, Netzwerk- und Datenbanktechnologien, k�nstliche Intelligenz, aber auch Marketing, Vertrieb, Projektmanagement und Recht."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was ist Informatik?"
                                },
                                shouldEndSession = false
                            }
                        });


                    case "GetSE":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"50% Betriebswirtschaft und 50% Ei Tii � mit Fokus auf Kunden und L�sungen in Ei Tii-Projekten. Genau das Richtige, wenn dir Informatik zu technisch, und Wirtschaftsinformatik zu betriebswirtschaftlich ist."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Was ist Software Engineering?"
                                },
                                shouldEndSession = false
                            }
                        });


                    case "GetAusland":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Na klar. Jeder Student der Bock auf das Ausland hat, wird sogar zus�tzlich von uns finanziell unterst�tzt. Frage mich doch, wo du �berall hin kannst!"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Klar kannst du ins Ausland."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetLocation":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Du kannst zum Beispiel nach Palo Alto in den USA. Wir und unsere Partner haben �berall auf der Welt Standorte, bei welchen du Praxiseins�tze machen kannst. Auch w�hrend der Theorie kannst du im Ausland auf Partnerhochschulen studieren, egal ob Australien, U S A, Finnland oder Singnapur. Hast du noch mehr Fragen f�r mich?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Es gibt �berall Standorte auf der Welt. USA oder Finnland, such dir was aus!"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetBewerbung":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Das ist ganz einfach. Du schickst uns deine Bewerbungsunterlagen einfach per Mail zu. Wir laden dich zu einem Bewerbertag ein, wenn uns deine Bewerbung gef�llt. Wenn du uns dort �berzeugst und dein Interesse an H P E zeigst, bekommst du von uns wenig sp�ter eine Zusage. M�chtest du vielleicht noch etwas wissen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Schick uns deine Bewerbung und wir laden dich zum Bewerbertag ein!"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetWannBewerbung":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Jederzeit. F�lle doch jetzt unseren Kontaktbogen aus!"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Jederzeit."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetWoWohnstDu":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Es gibt Standorte �berall in Deutschland! In welchem Bundesland wohnst du?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Standorte gibt es in ganz Deutschland."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetNiedersachsen":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Niedersachsen haben wir einen Standort in Hannover. M�chtest du noch mehr wissen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Wir sitzen hier in Hannover."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetBayern":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Bayern haben wir einen Standort in M�nchen und N�rnberg. M�chtest du noch mehr wissen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Wir sind hier in M�nchen und N�rnberg vertreten."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetBerlin":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Na klar, In Berlin haben wir einen Standort. Hast du sonst noch Fragen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"In Berlin sind wir auch vertreten."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetBrandenburg":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Brandeburg haben wir leider keinen Standort. Hast du noch eine Frage?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"In Brandenburg gibt es keinen Standort."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetBremen":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Bremen haben wir leider keinen Standort. Stelle mir doch noch mehr Fragen!"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"In Bremen haben wir keinen Standort."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetBW":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Baden W�rttemberg haben wir einen Standort in B�blingen. Gibt es sonst noch etwas, was du mich fragen willst?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Dort sitzen wir in B�blingen."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetHamburg":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Hamburg haben wir selbstverst�ndlich auch einen Standort. Gibt es sonst noch etwas, was du mich fragen willst?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"In Hamburg haben wir auch einen Standort."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetHessen":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Hessen haben wir einen Standort in Bad Homburg. Gibt es sonst noch etwas, was du mich fragen willst?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"In Bad Homburg gibt es einen Standort."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetMeckPomm":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Mecklenburg Vorpommern haben wir leider keinen Standort. Willst du noch etwas wissen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"In Mecklenburg Vorpommern haben wir keinen Standort."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetRheinlandPfalz":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Rheinland Pfalz haben wir leider keinen Standort. Gibt es sonst noch etwas, was du mich fragen willst?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"In Rheinland Pfalz haben wir keinen Standort."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetNRW":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Nordrhein Westfalen haben wir einen Standort in Ratingen. Hast du noch mehr Fragen f�r mich?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Ja, in Ratingen."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetSaarland":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Im Saarland haben wir leider keinen Standort. Kann ich dir noch weiter helfen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Im Saarland haben wir keinen Standort."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetSachsen":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Ja, da haben wir einen Standord in Leipzig. Willst du mich noch etwas fragen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Ja, in Leipzig"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetSachsenAnhalt":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Sachsen Anhalt haben wir leider keinen Standord. Hast du sonst noch Fragen an mich?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"In Sachsen-Anhalt haben wir keinen Standort."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetSchleswigHolstein":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Schleswig Holstein haben wir leider keinen Standort.  Kann ich dir sonst noch behilflich sein?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"In Schleswig-Holstein haben wir keinen Standort."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetThuringen":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"In Th�ringen haben wir leider keinen Standort. Kann ich dir sonst noch behilflich sein?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"In Th�ringen haben wir keinen Standort."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GettingStarted":
                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Gr�� Gott, Willkommen bei der Alliance. Das DualStudy Universum ist riesig. Dein Studium besteht aus Theorie und Praxisteilen. M�chtest du zuerst etwas �ber die Theorie oder die Praxis erfahren?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Willkommen bei der Alliance!"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetAlliance":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Die Alliance ist der Zusammenschluss der Unternehmen H P E, H P Inc., D X C, Micro Focus und SanData. Kann ich dir sonst noch weiterhelfen"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Der Zusammenschluss mehrere Verbundspartner mit HPE."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetWarumDual":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Besonders beim dualen Studium sind die kleinen Kurse mit maximal 30 Leuten, und nicht wie in der Uni mit 400 oder mehr. Au�erdem erh�lst du monatliches Gehalt und bist dadurch finanziell im Futter. Zudem bist du praxisnah unterwegs, da sich Theorie- und Praximodule alle 3 Monate abwechseln. Hast du noch eine Frage?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Kleine Kurse, Gehalt und Praxisn�he."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetWarumHPE":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Besonders bei H P E ist die amerikanische Firmenkultur. Es gibt �berall Kaffeecken, du duzt deinen Chef, bekommst Weihnachts- und Urlaubsgeld und noch viel mehr. H P E ist eine gro�e Familie, wo jeder jeden kennt! Kann ich dir noch eine Frage beantworten?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Besonders ist die amerikanische Firmenkultur."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetVorkenntnisse":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Du brauchst Abitur, einen Schnitt von mindestens 2,5 und ein gro�es Interesse an unserem Unternehmen."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Man braucht ein gutes Abitur und Interesse an HPE."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetWeekOne":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Am Anfang geht es eine Woche nach �sterreich. Dort lernen sich alle Studenten kennen. Dann gehts ab in die Uni. Au�erdem statten wir dich mit einem Laptop aus. Frage mich doch noch mehr, ich werde nicht m�de!"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Es geht auf eine Seminarfahrt nach Baad f�r alle Studenten."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetMathe":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Der �u�erst geniale Entwickler, Jakob Wiemer, dieses Alexa Skills ist die absolute Mathekartoffel. Solange du flei�ig bist ist alles im gr�nen Bereich. Kann ich dir noch eine Frage beantworten?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Mathe ist keine gro�e Sache, oder?"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetMaster":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Na klar. Du kannst nach erfolgreichen Bachelor bei uns ins Masterprogramm von Dual Study gehen! Welche Frage hast du jetzt an mich?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Na klar kannst du einen Master machen!"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetAfterStudium":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Nach dem Studium kannst Du entweder das Masterprogramm machen oder wirst von uns direkt �bernommen. Bei H P E werden 99% aller dualen Studenten �bernommen! Gut zu wissen, oder? Welche Frage jetzt?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Masterstudium oder �bernahme bei HPE"
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetAnstrengend":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Das duale Studium ist ein Intensivstudium, welches dich fordern wird. Jedoch wirst du von H P E bezahlt und du musst dich nicht um eine Nebent�tigkeit k�mmern wie normale Studenten. Brauchst du noch mehr Infos?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Das duale Studium ist ein Intensivstudium."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetKlausuren":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Das h�ngt ganz davon ab, wie flei�ig du vorher lernst. Wenn du dich gut vorbereitest sind die Klausuren kein Problem. Noch etwas, was du mich fragen willst?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Gut vorbereiten und schon besteht man die Klausuren."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetStudenten":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Momentan haben wir rund 350 Studenten. Wir f�rdern besonders das Miteinander, so geht es am Anfang des Studiums gemeinsam auf eine Seminarfahrt nach �sterreich. Kann ich dir noch eine Frage abnehmen?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Wir haben rund 350 Studenten."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetFreizeit":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Du hast 30 Tage Urlaub und bist von Montag bis Freitag rund 8 Stunden in der Uni oder bei der Arbeit. Danach kannst du deine Zeit frei gestalten. Kann ich dir noch eine Frage beantworten?"
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"30 Tage Urlaub und von Montag bis Freitag in der Uni oder bei der Arbeit."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "GetEntwickler":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Der Entwickler dieses Skills ist Jakob Wiemer."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Jakob Wiemer hat diesen Skill entwickelt."
                                },
                                shouldEndSession = false
                            }
                        });

                    case "NeuerDefault":

                        return req.CreateResponse(HttpStatusCode.OK, new
                        {
                            version = "1.0",
                            sessionAttributes = new { },
                            response = new
                            {
                                outputSpeech = new
                                {
                                    type = "PlainText",
                                    text = $"Hmmm, das habe ich nicht verstanden. Wiederhole doch deine Frage nochmal oder wende dich an den �u�erst kompetenten Messemitarbeiter."
                                },
                                card = new
                                {
                                    type = "Simple",
                                    title = "HPE Duales Studium - App Edition",
                                    content = $"Hmm, das habe ich nicht verstanden."
                                },
                                shouldEndSession = false
                            }
                        });

                    default:
                        return DefaultRequest(req);
                }
            }
            else
            {
                return DefaultRequest(req);
            }
        }
        private static HttpResponseMessage DefaultRequest(HttpRequestMessage req)
        {
            return req.CreateResponse(HttpStatusCode.OK, new
            {
                version = "1.0",
                sessionAttributes = new { },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Hmmm, das habe ich nicht verstanden. Wiederhole doch deine Frage nochmal oder wende dich an den �u�erst kompetenten Messemitarbeiter."
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "HPE Duales Studium - App Edition",
                        content = "Das habe ich nicht verstanden."
                    },
                    shouldEndSession = false
                }
            });
        }
    }
}