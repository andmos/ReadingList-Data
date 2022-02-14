import { readJSON, writeJSON, } from 'https://deno.land/x/flat@0.0.14/mod.ts' 

const filename = Deno.args[0]

await writeJSON(filename, await readJSON(filename), null, 2);
