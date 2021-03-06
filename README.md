# MangaRack

MangaRack is a small console application capable of synchronizing manga series from popular online manga scans and scanlations websites. Each synchronized chapter is stored on your computer as a comic book archive, optionally with additional embedded information (such as the writer and summary) ready to be imported to ComicRack.

## Motivation

It is trivial to find downloadable sources for anime, but this is not the case for manga. It is often tedious to find the series you are looking for, and the series that can be found often come in unfamiliar archives and without an option for embedded information. Reading series online is possible, but is also uncomfortable, especially when you are used to a light reading device and ComicRack. This issue has been programmatically solved by creating ComicRack-ready archives directly from these familiar online resources.

## History/Upgrading

More than a year has passed since the initial release of MangaRack. The combined experience of managing hundreds of series, thousands of chapters and millions of pages has been an interesting learning experience. The previous version would attempt to normalize chapter numbering. A good idea, but it actually makes it more difficult to manage a library. The new version will only attempt to 'guess' chapter numbers when not available, and will not track synchronized material. Instead, a number of options and filters are available to customize synchronization. If you are upgrading, you have to re-synchronize your entire library (please accept our sincere apologies).

## Questions/Issues

If you have a question or issue, go to the issues (https://github.com/Deathspike/mangarack/issues) and check if another item is available describing the same situation. If there is no such available item, please open one to get developer attention and have the question answered or issue resolved.

## Instructions

MangaRack is a console application. A number of options and filters are available to customize the way synchronization works, while each additional input represents a unique identifier for an online resource (usually the address of the series). Running the application without command line parameters will put the application into batch-mode, in which each line of the same-name text file is processed as a command line parameter instead.

### Basic Usage

#### Microsoft Windows

	1. Ensure Microsoft .NET Framework 4 is installed (http://www.microsoft.com/en-us/download/details.aspx?id=17851).
	2. Download the 'MangaRack for NET' archive from the Build directory.
	3. Extract the contents of the archive to a directory in which to synchronize.
	4. Open the text file and add unique identifiers of manga series to synchronize.
	5. Run MangaRack and wait for the synchronization to be completed.
	6. (Optionally) Import the directory in ComicRack and synchronize to a reading device.
	7. Have fun reading!

#### Other

	1. Ensure Mono 2.10.8+ is installed. Debian/Ubuntu requires `sudo apt-get install mono-runtime mono-gmcs libgdiplus libmono-system-data2.0-cil`
	2. Download the 'MangaRack for Mono' archive from the Build directory.
	3. Extract the contents of the archive to a directory in which to synchronize.
	4. Open the text file and add unique identifiers of manga series to synchronize.
	5. Run MangaRack and wait for the synchronization to be completed.
	6. (Optionally) Import the directory in ComicRack and synchronize to a reading device.
	7. Have fun reading!
	
### Advanced Usage

	Usage: mangarack [options] [uniqueIdentifier, ...]
	
	-a, --animation      Disable animation framing.
	-d, --duplication    Disable duplication prevention.
	-f, --footer         Disable MF footer incision (requires image processing).
	-g, --grayscale      Disable grayscale size comparison and save.
	-i, --image          Disable image processing.
	-k, --keep-alive     Disable keep-alive behavior.
	-m, --meta           Disable embedded meta information.
	-r, --repair         Disable repair and error tracking.
	-t, --total          Disable total elapsed time notification.
	-w, --worker         Disable worker threads.
	-e, --extension      The file extension for each output file. (Default: cbz)
	-c, --chapter        The chapter filter.
	-v, --volume         The volume filter.
	-p, --parallel       The maximum parallel worker threads. (Default: # cores)
	--help               Display this help screen.

#### --animation (-a)

The toggle to disable animation framing. This is the process of detecting animated pages and extracting the last frame. The feature was added to accommodate series in which pages are provided as an animation, presumably added to fool naïve synchronization implementations into synchronizing an incorrect page.

#### --duplication (-d)

The toggle to disable duplication prevention. This is the process of detecting an existing archive and preventing re-synchronization. The feature was added to prevent re-synchronization of chapters that had already been synchronized, and thus to reduce bandwidth consumption and allow for incremental synchronization.

#### --footer (-f)

The toggle to disable footer incision. This is the process of detecting a textual footer in a page synchronized from the MangaFox provider and programmatically removing it. The feature was added to remove distracting announcements from pages, which reduce reading visibility and increase page dimensions and file size.

#### --grayscale (-g)

The toggle to disable grayscale size comparison and save. This is the process of detecting and correcting an incorrect page storage format. The feature was added to reduce the file size of lossless PNG grayscale pages that have been provided in a larger-than-necessary storage format.

#### --image (-i).

The toggle to disable image processing. This is the process of image manipulation to normalize color and contrast, and to sharpen each page. The feature was added to improve the overall quality of synchronized pages. Note that this is the most CPU intensive operation that can occur during synchronization. **This feature is not compatible with non-Windows-based operating systems.**

#### --keep-alive (-k)

The toggle to disable keep-alive behavior. This is the process of pausing the console application after synchronization. The feature was added to prevent the command prompt from disappearing on Windows-based operating systems, improving usability for novice users.

#### --meta (-m)

The toggle to disable embedded meta-information. This is the process of creating and embedding a `ComicInfo.xml` file to each synchronized archive. The feature was added to give applications capable of handling meta-information (such as ComicRack) detailed information about the series and chapter.

#### --repair (-r)

The toggle to disable repair and error tracking. This is the process of generating an additional error file when encountering a broken page and repairing archives with broken pages. The feature was added to allow repairing of comic archives without requiring full re-synchronization or manual management.

#### --total (-t)

The toggle to disable total elapsed time notification. This is the process of computing the total synchronization time and presenting it prior to exit or keep-alive behavior. The feature was added to give feedback of the overall elapsed system time of long running synchronizations.

#### --worker (-w)

The toggle to disable worker threads. This is the process of spawning additional threads to run synchronizations in parallel. The feature was added to improve performance of synchronization and image manipulation by allowing the networking and computation load to be distributed to each available CPU.

#### --extension (-e)

The file extension for each output file. Each output file is formatted with the series title, the volume number and the chapter number, followed by a file extension. The default file extension is *cbz*, which represents a Comic Book Archive. The configuration option was made available to allow writing a custom file extension without depending on an external tool.

#### --chapter (-c)

The chapter filter. This filter influences which chapters are subject to synchronization. A positive number indicates that all chapters above the provided number are to be synchronized, while a negative number indicates that all chapters below the provided absolute number are to be synchronized.

#### --volume (-v)

The volume filter. This filter influences which volumes are subject to synchronization. A positive number indicates that all volumes above the provided number are to be synchronized, while a negative number indicates that all volumes below the provided absolute number are to be synchronized.

#### --parallel (-p)

The maximum parallel worker threads. This specified amount is used when worker threads have not been disabled to set the maximum degree of parallelism. By default, this value equals the amount of available cores in the system. This feature was added to provide control over the maximum amount of resource utilization.
