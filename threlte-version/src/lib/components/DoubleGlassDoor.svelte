<script lang="ts">
	import { T } from "@threlte/core";
	import { Materials } from "$lib/materials";
	import { BoxGeometry, CylinderGeometry } from "three";

	const material = Materials.glass;
	const metal = Materials.white;

	const doorGeometry = new BoxGeometry(0.01, 3, 1);
	const connectorGeometry = new CylinderGeometry(0.02, 0.02, 0.1);

	export let position: [number, number, number] = [0, 0, 0];
	export let rotation: number = 0;
</script>

<T.Group {position} rotation={[0, rotation, 0]}>
	<T.Mesh {material} geometry={doorGeometry} position={[0, 0, 0.5]} />
	<T.Mesh {material} geometry={doorGeometry} position={[0, 0, -0.5]} />
	<T.Mesh {material} position={[0, 1.95, 0]}>
		<T.BoxGeometry args={[0.01, 0.9, 1.8]} />
	</T.Mesh>
	<T.Mesh material={metal} position={[0, 2.45, 0]}>
		<T.BoxGeometry args={[0.2, 0.1, 2]} />
	</T.Mesh>
	<T.Mesh material={metal} position={[0, 0.45, 0.95]}>
		<T.BoxGeometry args={[0.2, 3.9, 0.1]} />
	</T.Mesh>
	<T.Mesh material={metal} position={[0, 0.45, -0.95]}>
		<T.BoxGeometry args={[0.2, 3.9, 0.1]} />
	</T.Mesh>
	<T.Mesh
		material={metal}
		rotation={[0, 0, Math.PI / 2]}
		geometry={connectorGeometry}
		position={[0, 0.5, 0.1]}
	/>
	<T.Mesh
		material={metal}
		rotation={[0, 0, Math.PI / 2]}
		geometry={connectorGeometry}
		position={[0, 0, 0.1]}
	/>
	<T.Mesh
		material={metal}
		rotation={[0, 0, Math.PI / 2]}
		geometry={connectorGeometry}
		position={[0, 0.5, -0.1]}
	/>
	<T.Mesh
		material={metal}
		rotation={[0, 0, Math.PI / 2]}
		geometry={connectorGeometry}
		position={[0, 0, -0.1]}
	/>
</T.Group>
