# Stardust Sound Patcher
Stardust Sound Patcher is a tool to replace instrument samples and sound effects for CPS3 ROMs.

It was originally created to help users distribute sound mods for *JoJo's Bizarre Adventure: Heritage for the Future*
more effectively (without having to resort to IPS patching or sharing entire sound files).  However, it will also 
work for other CPS3 games, such as *Street Fighter III* and *Red Earth*.

With this tool, you can adjust the sampling rate of the raw audio data, load sound files at specific points in the track,
and distribute collections of sound patches via zip files.  The program automatically converts all imported audio tracks 
to the correct format and sampling rate, meaning less busy-work for users and soundmodders.

Sound patches are distributed as zip files containing all of the necessary sound files, in addition to a `patch.json`,
which lets the program know which locations to patch sounds in the ROM's 30 and 31 files.

This tool is intended for use on Final Burn Alpha v0.2.96 ROMs.  It currently does not work on ROMs intended for
FBA v0.2.97 or later.  Do not ask me where to get said ROMs.  Google is your friend.

## Special Thanks
 - Everyone on the HFTF Discord for helping out with general romhacking stuff
