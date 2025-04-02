<script lang="ts">
	import { T } from "@threlte/core";
	import { Materials } from "$lib/materials";
	import { BoxGeometry } from "three";

	const pillarGeometry = new BoxGeometry(1, 4, 1);
	const wallGeometry = new BoxGeometry(3.5, 4, 0.2);

	export let position: [number, number, number];
</script>

<T.Group {position}>
	<T.Mesh material={Materials.yellow} position={[0, 0, 0]}>
		<T.BoxGeometry args={[3.5, 1, 3.5]} />
	</T.Mesh>

	<T.Mesh material={Materials.black} position={[2.25, 0, 0]}>
		<T.BoxGeometry args={[1, 1, 3.5]} />
	</T.Mesh>

	<T.Mesh material={Materials.black} position={[2.25, 4, 0]}>
		<T.BoxGeometry args={[1, 1, 1.5]} />
	</T.Mesh>

	<T.Mesh
		material={Materials.black}
		geometry={pillarGeometry}
		position={[2.25, 2.5, 1.25]}
	/>

	<T.Mesh
		material={Materials.black}
		geometry={pillarGeometry}
		position={[2.25, 2.5, -1.25]}
	/>

	<T.Mesh
		material={Materials.yellow}
		geometry={wallGeometry}
		position={[0, 2.5, -1.65]}
	/>

	<T.Mesh
		material={Materials.yellow}
		geometry={wallGeometry}
		position={[0, 2.5, 1.65]}
	/>

	<T.Mesh material={Materials.yellow} position={[-1.65, 2.5, 0]}>
		<T.BoxGeometry args={[0.2, 4, 3.1]} />
	</T.Mesh>
</T.Group>
