#Posh Markdown
Posh == PowerShell
Markdown == Markdown formatting

Posh Markdown is a module for PowerShell (my first), that let's you pipe markdown content through a commandlet and then out to, well, wherever you want to send it.

Ultimately I want to build up a PowerShell and .Net environment for scripting a blog site.

That part is an experiment, but this part, Posh Markdown, can stand alone and be useful.

#Quick How-To
All you really need is the DLL.
    import-module C:\<YOUR PATH HERE>\powershellMarkdown.dll

Once you import the module you can see it by calling Get-Module.

Now let's *pipe the sh|t right outta your home!* 
I mean, let's pipe some markdown text through our cmdlet.

    Get-Content Markdown_Documentation_Basics.text | Out-String | ConvertFrom-Markdown -AutoHyperlink -AutoNewlines -EncodeProblemUrlCharacters -LinkEmails -StrictBoldItalic -Verbose

The example uses one of the test files from MarkdownSharp.

-Get-Content reads the file into an string array.
-Out-String turns that array into a single string much like the one we need for conversion.
-ConvertFrom-Markdown is essentially a comdlet wrapper for MarkdownSharp.
--All the options are, well, optional. Try including them or not to get the results you want.

##PowerShell
Command line environment for Windows. Allows for scripting in the vein of Unix.

Big difference: Unix passes text around whereas PowerShell passes .Net objects.

I think PowerShell is one of the best kept secrets in the Windows world. You can do a ton with PowerShell if you learn not to fear the commandline.

##Markdown
Markdown is a way of formatting plain text documents in such a way that they can be easily (he said with great confidence) into HTML.

Lends itself to super simple writing. Gets the formatting out of the way.

Popular with some websites (like Github and StackOverflow) because (among other things) it allows for formatting without accepting raw HTML from users.

##MarkdownSharp
The .Net library used by StackOverflow. 

This is a base library for doing the Markdown conversions.

I'm linking the DLL into a little project so that you can call it in PowerShell as a commandlet.

 
