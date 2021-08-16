module.exports = {
  devServer: {
    proxy: {
      '^/api': {
        target: 'https://localhost:44390',
        changeOrigin: true,
        logLevel: 'debug',
        pathRewrite: { '^/api': '/' },
      },
    },
  },
}