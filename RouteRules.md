# Route Rules Syntax #

The routing rules have a syntax that allows parameters to be defined in the url.

# Background #

Meaningful urls means there are parameters in the URL that are useful. For example:
  * http:\\example.com\products\123\
  * http:\\example.com\students\abba\
  * http:\\example.com\blog\posts\2011\october\13

The routing rules describe where parameters can be found in the url. The most simple rule is the bracket defintion

  * http:\\example.com\products\[productId](productId.md)\
  * http:\\example.com\students\[username](username.md)\
  * http:\\example.com\blog\posts\[year](year.md)\[month](month.md)\[date](date.md)

# Details #
The Microsoft Regex library is use to replace a route parameter with a regex pattern.

The url

`http:\\example.com\products\[productId]\`

will be turned into the regex pattern:

`http:\\example.com\products\(?<productId>[^/^?]+)\`

**Regex Pattern Explaination**
|`?<productId>`| .Net style for named capture group `productId`. This makes it possible to look up a match by name|
|:-------------|:-------------------------------------------------------------------------------------------------|
| `[^/^?]+` |Match anything other than  / or ? as part of the group.|


That means the following urls will match
  * http:\\example.com\products\123
  * http:\\example.com\products\123\
  * http:\\example.com\products\123\list
  * http:\\example.com\products\123\list\
  * http:\\example.com\products\123.json