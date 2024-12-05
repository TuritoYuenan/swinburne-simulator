<script lang="ts">
	import { T } from "@threlte/core";
	import { Gizmo, OrbitControls, Sky } from "@threlte/extras";
	import Level5 from "$lib/levels/Level5.svelte";
</script>

<Gizmo horizontalPlacement="left" paddingX={20} paddingY={20} />
<Sky elevation={1} />

<T.PerspectiveCamera
	makeDefault
	position={[0, 5, 20]}
	on:create={({ ref }) => {
		ref.lookAt(0, 1, 0);
	}}
>
	<OrbitControls enableDamping />
</T.PerspectiveCamera>

<!-- Lighting -->
<T.DirectionalLight intensity={2} position.z={-50} position.y={10} />
<T.AmbientLight intensity={0.2} />

<!-- Current Level -->
<Level5 />
