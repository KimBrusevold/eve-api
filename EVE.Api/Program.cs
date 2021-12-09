using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Net.Http;
using System.Web;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
//https://esi.evetech.net/latest/characters/
// https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-5.0
// MAIN
var eve = new EVE.Api.EVE();
string characterId = eve.ReadLocalSettings("CharacterID");
var character = await eve.CharacterAsync(characterId);
var characterB = await eve.CharacterAsync("325379244");


//var characterMail = character.GetMail();
var mailRes = eve.GetCharacterMail(characterId);



var options = new JsonSerializerOptions();
options.PropertyNameCaseInsensitive = true;
options.WriteIndented = true;


Console.WriteLine(JsonSerializer.Serialize(character, options));
Console.WriteLine(JsonSerializer.Serialize(characterB, options));
Console.WriteLine(JsonSerializer.Serialize(mailRes, options));

//static GetCharacterMail ()
//{

//    return mails;
//}