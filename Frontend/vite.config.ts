import { defineConfig } from 'vite';
import { resolve } from 'path';

export default defineConfig({
  build: {
    outDir: resolve(__dirname, '../wwwroot/dist'),
    emptyOutDir: true,
    lib: {
      entry: resolve(__dirname, 'src/main.ts'),
      fileName: 'bundle',
      formats: ['es'] 
    },
    target: 'es2022' 
  }
});
