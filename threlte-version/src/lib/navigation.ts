/**
 * Scroll into an element
 * @param e Element ID
 * @returns Callback function
 */
export function scrollTo(e: string) {
	return () => document.getElementById(e)?.scrollIntoView({ behavior: "smooth" });
}

/**
 * Open a link on a new tab
 * @param link URL to go into
 * @returns Callback function
 */
export const openLink = (link: string) => () => window.open(link);
