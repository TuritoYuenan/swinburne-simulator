import { MeshPhongMaterial } from "three"

const haikeiColor = {
	black: 0x001122, white: 0xFFFFFF, grey: 0x888277, red: 0xFF0066, orange: 0xF7770F,
	yellow: 0xFCAF3C, green: 0x009473, cyan: 0x4FACF7, blue: 0x0066FF, violet: 0x715DF2,
}

export const Materials = {
	// Paints
	red: new MeshPhongMaterial({ color: haikeiColor.red }),
	cyan: new MeshPhongMaterial({ color: haikeiColor.cyan }),
	black: new MeshPhongMaterial({ color: haikeiColor.black }),
	white: new MeshPhongMaterial({ color: haikeiColor.white }),
	yellow: new MeshPhongMaterial({ color: haikeiColor.yellow }),
	green: new MeshPhongMaterial({ color: haikeiColor.green }),

	// Glass
	glass: new MeshPhongMaterial({ color: haikeiColor.green, opacity: 0.4, transparent: true }),
}
