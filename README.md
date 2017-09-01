# Wunderpähkina vol. 7

(Scroll [down](#brilliant-cut-english) for English instructions.)

## Brilliant cut

Sinulle luovutetaan jalokiviraakamateriaalia ja tehtäväsi on leikata annettu materiaali tavalla, joka antaa mahdollisimman suuren voiton. Jalokiviraakamateriaali koostuu kolmenlaisista jalokivistä: timanteista, safiireista ja rubiineista. Syötedatan saat [tästä](input.json).

Jokaiselle jalokivelle on kerrottu seuraavat tiedot:

- `cuts`  => `size` mahdollisen leikkauksen koko
- `cuts` => `value` leikkauksen arvo
- `rawChunks` leikattavien raakakimpaleiden koko

Leikattuja tai käyttämättä jääneitä paloja ei voi yhdistää. Käyttämättä jääneet palat ovat hävikkiä ja niiden koot vähennetään voitosta. 

Esimerkki: 23 kokoinen raakatimanttikimpale voidaan leikata näillä tavoilla:

| Leikkaukset | Arvo | Hävikki | Voitto |
|-------------|------|---------|--------|
|17|25|6|19|
|11, 11|14+14=28|1|27|
|7, 7, 7|21|2|19|
|11, 7|21|5|16|
|11|14|12|2|
|7|7|16|-9|

Kerro meille kaikkien jalokivien leikkauksesta syntynyt suurin mahdollinen yhteenlaskettu voitto ja anna lähdekoodi, jolla selvitit sen.

### Säännöt

- Ratkaisu voi olla millä tahansa ohjelmointikielellä.
- Ratkaisun pitää tuottaa oikea vastaus.
- Elegantein ratkaisu voittaa.
- Nopeus on yksi eleganssin osa-alue.
- Vastauksen lähettäjä sallii ratkaisuun käytetyn lähdekoodin julkaisun.

Lähetä vastauksesi viimeistään perjantaina 15.9.2017 osoitteeseen [pahkina@wunderdog.fi](mailto:pahkina@wunderdog.fi). Raati kokoontuu perjantaina 22.9.2017 ja julkaisee voittajan sen jälkeen. 

Voittaja palkitaan Phillips Hue White and color ambiance -aloituspakkauksella.

## Brilliant cut (English)

Your task is to cut the given raw material of gemstones in a way that provides the biggest possible profit. There will be three types of gemstones: diamonds, sapphires and rubies.  You get the input data [here](input.json). 

For each gems, the following information is provided:

- `cuts` => `size`, the size of the cut
- `cuts` => `value`, the value of the cut in question
- `raw chunks`, the original size of the raw, un-cut chunks

Leftover chunks or fragments cannot be combined. Leftover chunks are counted as waste and they are substracted from the resulting profit.

For example: a raw diamond chunk size 23 can be cut in the following ways:

| Cuts | Value | Waste | Profit |
|-------------|------|---------|--------|
|17|25|6|19|
|11, 11|14+14=28|1|27|
|7, 7, 7|21|2|19|
|11, 7|21|5|16|
|11|14|12|2|
|7|7|16|-9|

Please send us the largest profit that may result from cutting the jewelleries, and the source code you used. 

### Rules

- You can use any programming language to solve the problem.
- A solution must  contain the right answer. 
- The winner will be the most elegant solution, decided by the Wundernut jury.
- Performance is a part of elegance.
- The participant gives Wunderdog the right to publish their solution.

Send your solution to [pahkina@wunderdog.fi](mailto:pahkina@wunderdog.fi) by the end of September 15, 2017. We will select the winner on September 22, 2017 and it will be announced after that.

The winner will be rewarded with Phillips Hue White and color ambiance starter kit.
